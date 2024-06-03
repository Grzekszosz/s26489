using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Context;

public partial class APBDContext: DbContext
{
    public APBDContext()
    {
        
    }

    public APBDContext(DbContextOptions<APBDContext> options) : base(options)
    {
        
    }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament>PrescriptionMedicaments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
                        .UseSqlServer(
                                        "Data Source=db-mssql;Initial Catalog=S26489;Integrated Security=True;Trust Server Certificate=True")
                        .LogTo(Console.WriteLine, LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ustawienie domyślnego schematu dla wszystkich tabel
        modelBuilder.HasDefaultSchema("APDBP");

        modelBuilder.Entity<PrescriptionMedicament>(p =>
        {
            p.HasKey(e=> new {e.IdMedicament,e.IdPrescription});
            p.HasOne(e => e.Medicament)
                            .WithMany(x => x.PrescriptionMedicaments)
                            .HasForeignKey(p => p.IdMedicament);
            p.HasOne(e => e.Prescription)
                            .WithMany(x => x.PrescriptionMedicaments)
                            .HasForeignKey(p => p.IdPrescription);
        });
    }
}   
