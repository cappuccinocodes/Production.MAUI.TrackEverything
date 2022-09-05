using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Maui.Timer.Models;

public class Timer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Indexed]
    [Required]
    public int CategoryId { get; set; }
}

public class TimerCategory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}

