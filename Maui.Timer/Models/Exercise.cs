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

    public TimeSpan Duration1 { get; set; }
    public TimeSpan Duration2 { get; set; }
    public TimeSpan Duration3 { get; set; }
    public TimeSpan Duration4 { get; set; }

    public int Repetitions1 { get; set; }
    public int Repetitions2 { get; set; }
    public int Repetitions3 { get; set; }
    public int Repetitions4 { get; set; }

    public decimal Intensity1 { get; set; }
    public decimal Intensity2 { get; set; }
    public decimal Intensity3 { get; set; }
    public decimal Intensity4 { get; set; }

    public decimal Distance1 { get; set; }
    public decimal Distance2 { get; set; }
    public decimal Distance3 { get; set; }
    public decimal Distance4 { get; set; }
}

