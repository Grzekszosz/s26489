using LegacyApp;

namespace LegacyAppTest;

public class UserServiceTests
{
    [Fact]
    public void ValidateUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstname = "John";
        string lastname = "Doe";
        string email = "mail";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void ValidateUser_Should_Return_False_When_Email_Without_At()
    {
        //Arrange
        string firstname = "John";
        string lastname = "Doe";
        string email = "mail.com";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void ValidateUser_Should_Return_False_When_Email_Without_Dot()
    {
        //Arrange
        string firstname = "John";
        string lastname = "Doe";
        string email = "mail.com";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void ValidateUser_Should_Return_False_When_Firstname_IsNull()
    {
        //Arrange
        string firstname ="";
        string lastname = "Doe";
        string email = "mai@l.com";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void ValidateUser_Should_Return_False_When_LastName_IsNull()
    {
        //Arrange
        string firstname = "John";
        string lastname = "";
        string email = "mail.com";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void ValidateUser_Should_Return_False_When_LastName_And_FirstName_IsNull()
    {
        //Arrange
        string firstname = "";
        string lastname = "";
        string email = "mail.com";
        int clientId = 1;
        var service = new UserService();
        //Act
        bool result = service.ValidateUser(firstname, lastname, email, clientId);
        //Assert
        Assert.Equal(false,result);
    }
    [Fact]
    public void ValidateDate_Should_Return_False_When_Age_Less_21()
    {
        DateTime birthDate = DateTime.Today.AddYears(-21).AddDays(1);
        var service = new UserService();
        //Act
        bool result = service.ValidateDate(birthDate);
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void ValidUser_Credits_Should_Return_False_When_Credits_Less_500()
    {
        var user = new User();
        var service = new UserService();
        //Act
        bool result = service.ValidUser_Credits(200,true);
        //Assert
        Assert.Equal(false,result);
    }

    [Fact]
    public void ValidUser_Credits_Should_Return_False_When_DontHave_CreditLimit()
    {
        var user = new User();
        var service = new UserService();
        //Act
        bool result = service.ValidUser_Credits(499,true);
        //Assert
        Assert.Equal(false,result);
    }
    
    
}