using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Maui.Timer.Models;

public class Exercise
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int Sets { get; set; }

    public TimeSpan? Duration { get; set; }

    [Required]
    public int Repetitions { get; set; }

    public decimal Intensity { get; set; }

    public decimal Distance { get; set; }
}

