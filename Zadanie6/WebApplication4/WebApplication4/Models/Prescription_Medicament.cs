using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

public class PrescriptionMedicament
{
    public int Dose { get; set; }
    [MaxLength(100)]
    public string Details { get; set; }
    [Key]
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set;}
    [Key]
    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; }
    
    
}