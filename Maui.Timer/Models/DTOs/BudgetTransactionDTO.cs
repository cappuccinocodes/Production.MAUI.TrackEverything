namespace Maui.Timer.Models;

public class BudgetTransactionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } 
}
