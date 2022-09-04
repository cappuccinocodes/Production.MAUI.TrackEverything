using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Maui.Timer.Models;

public class UberShift
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    public decimal Amount { get; set; }
}

