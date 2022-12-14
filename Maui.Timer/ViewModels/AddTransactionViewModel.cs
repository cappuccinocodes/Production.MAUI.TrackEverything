using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using Maui.Timer.Views;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddTransactionViewModel : BudgetViewModel
{
    public AddTransactionViewModel()
    {
        Date = DateTime.Now;

        TransactionsToView = new ObservableCollection<BudgetTransactionDTO>(Transactions
            .Select(x => new BudgetTransactionDTO
            {
                Id = x.Id,
                Date = x.Date,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Amount = x.Amount,
                CategoryName = Categories.Single(y => y.Id == x.CategoryId).Name
            }));
    }

    [ObservableProperty]
    ObservableCollection<BudgetTransactionDTO> transactionsToView;

    [ObservableProperty]
    int categoryId;
    [ObservableProperty]
    string name;
    [ObservableProperty]
    decimal amount;
    [ObservableProperty]
    DateTime date;
    [ObservableProperty]
    BudgetCategory selectedCategory;
    [ObservableProperty]
    BudgetCategory selectedCategoryFilter;
    [ObservableProperty]
    string nameFilter;

    [RelayCommand]
    async Task Add()
    {
        try
        {
            App.BudgetRepository.AddTransaction(new BudgetTransaction
            {
                Date = date,
                Amount = amount,
                Name = name,
                CategoryId = selectedCategory.Id
            });

            PopulateList();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.BudgetRepository.DeleteTransaction(id);

        PopulateList();
    }

    [RelayCommand]
    async Task NavigateToAddCategory()
    {
        await Shell.Current.GoToAsync(nameof(AddCategory));
    }

    [RelayCommand]
    async Task NavigateToReports()
    {
        await Shell.Current.GoToAsync(nameof(BudgetReports));
    }

    [RelayCommand]
    async Task PopulateForm(BudgetTransactionDTO transaction)
    {
        SelectedCategory = Categories.First(x => x.Id == transaction.CategoryId);
        Name = transaction.Name;
        Amount = transaction.Amount;
        Date = transaction.Date;
    }

    [RelayCommand]
    async Task FilterByCategory()
    {
        TransactionsToView =
            new ObservableCollection<BudgetTransactionDTO>(
                Transactions
                .Where(x => x.CategoryId == selectedCategoryFilter.Id)
                .Select(x => new BudgetTransactionDTO
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    Amount = x.Amount,
                    CategoryName = Categories.Single(y => y.Id == x.CategoryId).Name
                }));

    }

    [RelayCommand]
    async Task FilterByName()
    {
        TransactionsToView =
            new ObservableCollection<BudgetTransactionDTO>(
                Transactions
                .Where(x => x.Name.Contains(NameFilter))
                .Select(x => new BudgetTransactionDTO
                {
                    Id = x.Id,
                    Date = x.Date,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    Amount = x.Amount,
                    CategoryName = Categories.Single(y => y.Id == x.CategoryId).Name
                }));

    }

    void PopulateList()
    {
        Transactions = new ObservableCollection<BudgetTransaction>(App.BudgetRepository.GetAllTransactions());

        TransactionsToView = new ObservableCollection<BudgetTransactionDTO>(Transactions.Select(x =>
        new BudgetTransactionDTO
        {
            Id = x.Id,
            Date = x.Date,
            Name = x.Name,
            CategoryId = x.CategoryId,
            Amount = x.Amount,
            CategoryName = Categories.Single(y => y.Id == x.CategoryId).Name
        }));
    }
}
