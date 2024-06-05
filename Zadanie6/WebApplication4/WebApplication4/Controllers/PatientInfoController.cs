using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Context;
using WebApplication4.Models;

namespace WebApplication4.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientInfoController : ControllerBase
{
    private readonly APBDContext dbContext;

    public PatientInfoController(APBDContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> getPatientInfo(int id)
    {
        try
        {
            var patient = await dbContext.Patients
                            .Include(p => p.Prescriptions)
                            .ThenInclude(d => d.Doctor)
                            .Include(p => p.Prescriptions)
                            .ThenInclude(pr => pr.PrescriptionMedicaments)
                            .ThenInclude(m => m.Medicament)
                            .FirstOrDefaultAsync(p => p.IdPatient == id);
            if (patient == null)
            {
                return NotFound("Nie znaleziono pacjenta o takim ID");
            }
            return Ok(patient);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}