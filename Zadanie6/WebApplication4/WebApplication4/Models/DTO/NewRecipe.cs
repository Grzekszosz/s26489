namespace WebApplication4.Models.DTO;

public class NewRecipe
{
    public Patient patient { get; set; }
    
    
}

/*
 {
    "IdPatient": 1,
    "FirstName": "Jan",
    //...
    "Prescriptions": [
    {
        "IdPrescription": 1,
        . "Date": "2012-01-01",
        "DueDate": "2012-01-01",
        "Medicaments": [
        {
            "IdMedicament": 1,
            "Name": "AAA",
            "Dose": 10,
            "Description": "AAA"
        }
    ]
    "Doctor": {
        "IdDoctor": 1,
        "FirstName": "AAA"
    }
    }
    ]
}
 */
 
 //////////////
 /*

 "prescription": {
     "idPrescription": 0,
     "date": "2024-06-04T19:33:13.130Z",
     "dueDate": "2024-06-04T19:33:13.130Z",
     "prescriptionMedicaments": [
     {
         "dose": 0,
         "details": "string",
         "idMedicament": 0,
         "medicament": {
             "idMedicament": 0,
             "name": "string",
             "description": "string",
             "type": "string",
             "prescriptionMedicaments": [
             "string"
                             ]
         },
         "idPrescription": 0,
         "prescription": "string"
     }
     ],
     "patient": {
         "idPatient": 0,
         "firstName": "string",
         "lastName": "string",
         "birthDate": "2024-06-04T19:33:13.130Z",
         "prescriptions": [
         "string"
                         ]
     },
     "doctor": {
         "idDoctor": 0,
         "firstName": "string",
         "lastName": "string",
         "email": "string",
         "prescriptions": [
         "string"
                         ]
     }
 }
 }
 
 {
  "patient": {
    "idPatient": 0,
    "firstName": "string",
    "lastName": "string",
    "birthDate": "2024-06-04T19:48:24.672Z",
    "prescriptions": [
      {
        "idPrescription": 0,
        "date": "2024-06-04T19:48:24.672Z",
        "dueDate": "2024-06-04T19:48:24.672Z",
        "prescriptionMedicaments": [
          {
            "dose": 0,
            "details": "string",
            "idMedicament": 0,
            "medicament": {
              "idMedicament": 0,
              "name": "string",
              "description": "string",
              "type": "string",
              "prescriptionMedicaments": [
                "string"
              ]
            },
            "idPrescription": 0,
            "prescription": "string"
          }
        ],
        "patient": "string",
        "doctor": {
          "idDoctor": 0,
          "firstName": "string",
          "lastName": "string",
          "email": "string",
          "prescriptions": [
            "string"
          ]
        }
      }
    ]
  }
}
 
 
 */