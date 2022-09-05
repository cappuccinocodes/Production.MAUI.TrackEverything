using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddTimerViewModel : ObservableObject
{
    public AddTimerViewModel()
    {
        Categories = new ObservableCollection<TimerCategory>(App.TimerRepository.GetAllCategories());
        FetchTimers();
    }

    [ObservableProperty]
    ObservableCollection<Models.Timer> timers;

    [ObservableProperty]
    ObservableCollection<TimerCategory> categories;

    [ObservableProperty]
    TimeSpan duration;

    [ObservableProperty]
    int categoryId;
    [ObservableProperty]
    string categoryName;
    [ObservableProperty]
    DateTime date;
    [ObservableProperty]
    TimerCategory selectedCategory;

    [RelayCommand]
    async Task AddCategory()
    {
        try
        {
            App.TimerRepository.AddCategory(new TimerCategory
            {
                Name = categoryName,
            });

            Categories = new ObservableCollection<TimerCategory>(App.TimerRepository.GetAllCategories());

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    async Task AddTimer()
    {
        try
        {
            App.TimerRepository.AddTimer(new Models.Timer
            {
                CategoryId = categoryId,
                Duration = Duration,
                Date = Date,
            });

            FetchTimers();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void DeleteCategory(int id)
    {
        Timers = new ObservableCollection<Models.Timer>(App.TimerRepository.GetAll());
    }

    void FetchTimers()
    {
        Timers = new ObservableCollection<Models.Timer>(App.TimerRepository.GetAll());
    }

}
