namespace Maui.Timer.Models;

public class TimerDTO
{
    public int Id { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }    
}


