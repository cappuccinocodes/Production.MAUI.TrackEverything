using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Maui.Timer.Models;

public class BudgetTransaction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Indexed]
    [Required]
    public int CategoryId { get; set; }
}

public class BudgetCategory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}

