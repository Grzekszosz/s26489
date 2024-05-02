namespace WebApplication2.Model;

public class Order
{
    public int iOrder { get; set; }
    public int idProduct { get; set; }
    public int orderAmount { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime fulfilledAt { get; set; }
}