using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using Maui.Timer.Views;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddCategoryViewModel : BudgetViewModel
{
    [ObservableProperty]
    string name;

    [RelayCommand]
    async Task Add()
    {
        try
        {
            App.BudgetRepository.AddCategory(new BudgetCategory
            {
                Name = name
            });

            Categories = new ObservableCollection<BudgetCategory>(App.BudgetRepository.GetAllCategories());

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.BudgetRepository.DeleteCategory(id);
        Categories = new ObservableCollection<BudgetCategory>(App.BudgetRepository.GetAllCategories());
    }

    [RelayCommand]
    async Task NavigateToAddTransaction()
    {
        await Shell.Current.GoToAsync(nameof(AddTransaction));
    }
}
