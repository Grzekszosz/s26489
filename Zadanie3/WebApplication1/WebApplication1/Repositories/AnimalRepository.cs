using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        var validColumns = new List<string> { "Name", "Description", "Category", "Area" }; 
        if (!validColumns.Contains(orderBy))
        {
            if (orderBy.IsNullOrEmpty())
            {
                orderBy = "Name";
            }
            else
            {
                throw new ArgumentException($"Nie poprawny parametr: {orderBy}");
            }
        }

        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Nie udało się nawiązać połączenia z bazą");
        };
        using var cmd = new SqlCommand();
        cmd.Connection = con;
//string querry="SELECT IDAnimal, Name, Description, Category, Area  FROM s26489.APDBP.Animals ORDER BY  @orderBy"
        cmd.CommandText = $"SELECT IDAnimal, Name, Description, Category, Area  FROM s26489.APDBP.Animals ORDER BY {orderBy}";
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

    public int CreateAnimal(Animal animal)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        using var con = new SqlConnection(connectionString);
        con.Open();
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Nie udało się nawiązać połączenia z bazą");
        };
        using var cmd = new SqlCommand();
        cmd.Connection = con;
       cmd.CommandText = "INSERT INTO s26489.APDBP.Animals (IDAnimal, Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
    
}