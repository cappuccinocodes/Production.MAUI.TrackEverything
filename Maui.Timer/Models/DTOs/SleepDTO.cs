 namespace Maui.Timer.Models;

public class SleepDTO
{
    public int Id { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public TimeSpan Duration
    {
        get
        {
            return DateEnd - DateStart;
        }
    }
}

