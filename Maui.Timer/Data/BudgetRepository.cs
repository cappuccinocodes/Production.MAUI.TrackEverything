using Maui.Timer.Models;
using SQLite;
namespace Maui.Timer.Data;

public class BudgetRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public BudgetRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void CreateTables()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<BudgetCategory>();
            conn.CreateTable<BudgetTransaction>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    internal void AddTransaction(BudgetTransaction budgetTransaction)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(budgetTransaction);
    }

    internal void AddCategory(BudgetCategory budgetCategory)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(budgetCategory);
    }

    public List<BudgetTransaction> GetAllTransactions()
    {
        try
        {
            CreateTables();
            return conn.Table<BudgetTransaction>().OrderByDescending(x => x.Date).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<BudgetTransaction>();
    }

    public List<BudgetCategory> GetAllCategories()
    {
        try
        {
            CreateTables();
            return conn.Table<BudgetCategory>().OrderByDescending(x => x.Name).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<BudgetCategory>();
    }

    internal void DeleteCategory(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new BudgetCategory { Id = id });
    }

    internal void DeleteTransaction(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new BudgetTransaction { Id = id });
    }
}