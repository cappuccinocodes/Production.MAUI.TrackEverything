using CommunityToolkit.Mvvm.ComponentModel;
using Maui.Timer.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Maui.Timer.ViewModels;

public partial class BudgetReportsViewModel : BudgetViewModel
{
    private DateTime Today = DateTime.Today;

    public BudgetReportsViewModel()
    {
        Report = GetReport(Today.Month, Today.Year);
        AvailableYearMonths = GetAvailableYearMonths();
    }

    private ObservableCollection<string> GetAvailableYearMonths()
    {
        var uniqueYearMonth = Transactions.Select(t => new DateTime(t.Date.Year, t.Date.Month, 1).ToString("MMM,yy")).Distinct().ToList();
        return new ObservableCollection<string>(uniqueYearMonth);
    }

    private ObservableCollection<BudgetReport> GetReport(int month, int year)
    {
        return new ObservableCollection<BudgetReport>(Transactions
            .Where(x => x.Date.Month == month && x.Date.Year == year)
            .Join(Categories,
                  transaction => transaction.CategoryId,
                  category => category.Id,
                  (transaction, category) => new
                  {
                      CategoryId = category.Id,
                      Amount = transaction.Amount,
                      CategoryName = category.Name
                  })
            .GroupBy(x => x.CategoryName)
            .Select(x => new BudgetReport
            {
                Category = x.Key,
                Amount = x.Sum(y => y.Amount)
            })
            .OrderByDescending(x => x.Amount));
    }

    private ObservableCollection<BudgetReport> GetReport(string month)
    {
        return new ObservableCollection<BudgetReport>(Transactions
            .Join(Categories,
                  transaction => transaction.CategoryId,
                  category => category.Id,
                  (transaction, category) => new
                  {
                      Date = transaction.Date,  
                      CategoryId = category.Id,
                      Amount = transaction.Amount,
                      CategoryName = category.Name
                  })
            .Where(x => x.CategoryName == month)
            .GroupBy(x => x.Date.ToString("MMM"))
            .Select(x => new BudgetReport
            {
                Category = x.Key,
                Amount = x.Sum(y => y.Amount)
            })
            .OrderByDescending(x => x.Amount));
    }

    [ObservableProperty]
    private ObservableCollection<BudgetReport> report;

    [ObservableProperty]
    private ObservableCollection<string> availableYearMonths;

    [ObservableProperty]
    private string selectedYearMonth;

    [ObservableProperty]
    private string selectedCategory;

    partial void OnSelectedYearMonthChanged(string value)
    {
        var yearMonth = AvailableYearMonths[Int32.Parse(value)];

        var sub = yearMonth.Substring(3);

        var month = DateTime.ParseExact(yearMonth.Substring(0,3), "MMM", CultureInfo.InvariantCulture).Month;
        var year = DateTime.ParseExact(yearMonth.Substring(4), "yy", CultureInfo.InvariantCulture).Year;

        Report = GetReport(month, year);

    }

    partial void OnSelectedCategoryChanged(string value)
    {
        var category = Categories[Int32.Parse(value)].Name;

        Report = GetReport(category);

    }
}
