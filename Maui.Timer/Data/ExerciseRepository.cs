using Maui.Timer.Models;
using SQLite;
namespace Maui.Timer.Data;

public class ExerciseRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public ExerciseRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void CreateTables()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Exercise>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal void Add(Exercise exercise)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(exercise);
    }

    public List<Exercise> GetAll()
    {
        try
        {
            CreateTables();
            return conn.Table<Exercise>().OrderByDescending(x => x.Date).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<Exercise>();
    }

    internal void Delete(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new Exercise { Id = id });
    }
}