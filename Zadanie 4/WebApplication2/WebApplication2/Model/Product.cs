using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication2.Model;

public class Product
{   
    [Required]
    public int IDProduct { get; set; }
    [Required]
    public int IDWarehouse { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}