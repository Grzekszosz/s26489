using System.Runtime.InteropServices.JavaScript;

namespace WebApplication2.Model;

public class Product
{
    public int IDProduct { get; set; }
    public int IDWarehouse { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}