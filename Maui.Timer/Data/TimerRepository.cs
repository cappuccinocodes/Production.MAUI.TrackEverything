using Maui.Timer.Models;
using SQLite;
namespace Maui.Timer.Data;

public class TimerRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public TimerRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void CreateTables()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<TimerCategory>();
            conn.CreateTable<Models.Timer>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal void AddTimer(Models.Timer timer)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(timer);
    }

    internal void AddCategory(TimerCategory category)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(category);
    }

    public List<Models.Timer> GetAll()
    {
        try
        {
            CreateTables();
            return conn.Table<Models.Timer>().OrderByDescending(x => x.Date).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<Models.Timer>();
    }

    public List<TimerCategory> GetAllCategories()
    {
        try
        {
            CreateTables();
            return conn.Table<TimerCategory>().OrderByDescending(x => x.Name).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<TimerCategory>();
    }

    internal void DeleteCategory(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new TimerCategory { Id = id });
    }

    internal void DeleteTransaction(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new Models.Timer { Id = id });
    }
}