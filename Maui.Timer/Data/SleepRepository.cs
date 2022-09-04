using Maui.Timer.Models;
using SQLite;
namespace Maui.Timer.Data;

public class SleepRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public SleepRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void CreateTables()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Sleep>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal void Add(Sleep sleep)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(sleep);
    }

    public List<Sleep> GetAll()
    {
        try
        {
            CreateTables();
            return conn.Table<Sleep>().OrderByDescending(x => x.DateStart).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<Sleep>();
    }

    internal void Delete(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new Sleep { Id = id });
    }
}