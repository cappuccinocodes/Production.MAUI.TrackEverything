using CommunityToolkit.Mvvm.ComponentModel;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class BudgetViewModel: ObservableObject
{
    public BudgetViewModel()
    {
        Categories = new ObservableCollection<BudgetCategory>(App.BudgetRepository.GetAllCategories());
        Transactions = new ObservableCollection<BudgetTransaction>(App.BudgetRepository.GetAllTransactions());
    }

    [ObservableProperty]
    ObservableCollection<BudgetCategory> categories;

    [ObservableProperty]
    ObservableCollection<BudgetTransaction> transactions;

}
