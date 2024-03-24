using System;

namespace LegacyApp
{
    public class UserService
    {
        private static int _requriedAge=21;
        
        /** Nie zdecydowałem się na użycie Interfejsu gdyż wymagało by to lekkiej modyfikacji klasy ClientRepository **/
        private ClientRepository clientRepository;
        private UserCreditService userCreditService;

        public UserService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        public UserService(ClientRepository clientRepository, UserCreditService userCreditService )
        {
            this.clientRepository = clientRepository;
            this.userCreditService = userCreditService;
        }
        
        public UserService()
        {
            clientRepository = new ClientRepository();
            userCreditService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            ValidateUser( firstName,  lastName,  email, clientId);
            ValidateDate(dateOfBirth);
            
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            switch (client.Type)
            {
                case nameof(ClientType.VeryImportantClient):
                        user.HasCreditLimit = false;
                    break;
                
                case nameof(ClientType.ImportantClient):
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        creditLimit = creditLimit * 2;
                        user.CreditLimit = creditLimit;
                    }
                    break;
                
                default:
                    user.HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                        user.CreditLimit = creditLimit;
                    }
                    break;
            }


            int  userCreditLimit = user.CreditLimit;
            bool userHasCreditLimit = user.HasCreditLimit;
            ValidUser_Credits(userCreditLimit,userHasCreditLimit);
            UserDataAccess.AddUser(user);
            return true;
        }

        public bool ValidateUser(string firstName, string lastName, string email, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || int.IsNegative(clientId) ||
                int.IsEvenInteger(clientId) || !email.Contains('.') || !email.Contains('@'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        int CalculateAge(DateTime dateOfBirth)
        {
            int age =  DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day)
            {
                return age - 1;
            }
            else
            {
                return age;
            }
        }
        public bool ValidateDate(DateTime dateOfBirth)
        {
            if (DateTime.Now.Month<dateOfBirth.Month || CalculateAge(dateOfBirth) < _requriedAge )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
      public  bool ValidUser_Credits(int CreditLimit, bool hasCreditLimit)
        { 
            if (hasCreditLimit && CreditLimit < 500)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
}
