using Microsoft.AspNetCore.Mvc;
using WebApplication4.Context;
using WebApplication4.Models;
using WebApplication4.Models.DTO;

namespace WebApplication4.Controllers;
[Route("api/prescription")]
[ApiController]
public class PrescriptionController:ControllerBase
{
    private readonly APBDContext dbContext;

    public PrescriptionController(APBDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost("addPrescritpion")]
    public async Task<IActionResult> AddPrescription(NewRecipe dto)
    {
        try
        {
            if (dto.DueDate <= dto.Date)
            {
                return BadRequest("Podane są złe daty");
            }

            if (dto.Medicaments.Count > 10)
            {
                return BadRequest("Za dużo leków");
            }

            foreach (var med in dto.Medicaments)
            {
                var medicament = await dbContext.Medicaments.FindAsync(med.IdMedicament);
                if (medicament == null)
                {
                    return BadRequest("Jeden z medykamentów nie istnieje w bazie");
                }
            }
            
            var patient = await dbContext.Patients.FindAsync(dto.patient.IdPatient);
            if (patient == null)
            {
                //Nowy pacjent 
                patient = new Patient
                {
                    BirthDate = dto.patient.BirthDate,
                    FirstName = dto.patient.FisrtName,
                    IdPatient = dto.patient.IdPatient,
                    LastName = dto.patient.LastName
                };
                 dbContext.Patients.Add(patient);
                 await dbContext.SaveChangesAsync();
            }

            var doc = await dbContext.Doctors.FindAsync(dto.IdDoctor);
            if (doc == null)
            {
                return BadRequest("Podany doktor nie istnieje w bazie");
            }

            var pres = new Prescription
            {
                Date = dto.Date,
                DueDate = dto.DueDate,
                Doctor = doc,
                IdDoctor = doc.IdDoctor,
                IdPatient = patient.IdPatient
            };
            dbContext.Prescriptions.Add(pres);
            await dbContext.SaveChangesAsync();
            foreach (var medDto in dto.Medicaments)
            {
                
                PrescriptionMedicament presMed = new PrescriptionMedicament
                {
                    Details = medDto.Description,
                    Dose = medDto.Dose,
                    IdMedicament = medDto.IdMedicament,
                    IdPrescription = pres.IdPrescription,
                    Medicament = await dbContext.Medicaments.FindAsync(medDto.IdMedicament),
                    Prescription = pres
                };
                pres.PrescriptionMedicaments.Add(presMed);
                dbContext.PrescriptionMedicaments.Add(presMed);
            }
            dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        return Ok();
    }
}
