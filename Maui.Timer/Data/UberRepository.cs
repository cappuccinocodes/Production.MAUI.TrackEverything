using Maui.Timer.Models;
using SQLite;
namespace Maui.Timer.Data;

public class UberRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public UberRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void CreateTables()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<UberShift>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal void Add(UberShift uberShift)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(uberShift);
    }

    public List<UberShift> GetAll()
    {
        try
        {
            CreateTables();
            return conn.Table<UberShift>().OrderByDescending(x => x.Date).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<UberShift>();
    }

    internal void Delete(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new UberShift { Id = id });
    }
}