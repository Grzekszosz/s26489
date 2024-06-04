namespace WebApplication4.Models.DTO;

public class PrescriptionDTO
{
    public int IdPrescritpion { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueTime { get; set; }
    public ICollection<MedicamentDTO> Medicaments { get; set; }
    public DoctorDTO
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