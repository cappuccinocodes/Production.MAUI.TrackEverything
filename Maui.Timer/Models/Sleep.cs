using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Maui.Timer.Models;

public class Sleep
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public DateTime DateStart { get; set; }

    [Required]
    public DateTime DateEnd { get; set; }
}

