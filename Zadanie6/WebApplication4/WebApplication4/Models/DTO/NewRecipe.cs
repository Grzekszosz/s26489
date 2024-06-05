namespace WebApplication4.Models.DTO;

public class NewRecipe
{
    public PatientDTO patient { get; set; }
    public ICollection<MedicamentDTO>Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
} 

