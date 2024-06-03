using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public ICollection<PrescriptionMedicament>PrescriptionMedicaments { get; set; }
    
    public int IdPatient;
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    public int IdDoctor;
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }
    
}