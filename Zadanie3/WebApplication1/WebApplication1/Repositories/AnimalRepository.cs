using Microsoft.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("ConnectionString is not initialized!");
        };
        Console.WriteLine(con.State);
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IDAnimal, Name, Description, Category, Area  FROM s26489.APDBP.Animals ORDER BY IDAnimal";
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal
            {
                IDAnimal = (int)dr["IDAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
            };
            animals.Add(grade);
        }
        con.Close();
        return animals;
    }
    
}