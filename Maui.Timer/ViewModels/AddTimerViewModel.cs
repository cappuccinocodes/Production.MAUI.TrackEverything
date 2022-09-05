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
        FetchTimers(DateTime.Today);

        ViewDate = DateTime.Today;
        Date = DateTime.Today;
    }

    [ObservableProperty]
    ObservableCollection<Models.Timer> timers;

    [ObservableProperty]
    ObservableCollection<TimerDTO> timersToView;

    [ObservableProperty]
    ObservableCollection<TimerCategory> categories;

    [ObservableProperty]
    TimeSpan duration;

    [ObservableProperty]
    TimeSpan totalTime;

    [ObservableProperty]
    int categoryId;
    [ObservableProperty]
    string categoryName;
    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    DateTime today;

    [ObservableProperty]
    DateTime viewDate;

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
                CategoryId = SelectedCategory.Id,
                Duration = Duration,
                Date = Date,
            });

            FetchTimers(Date);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.TimerRepository.Delete(id);
        FetchTimers(ViewDate);
    }

    [RelayCommand]
    void ChooseViewDate()
    {
        FetchTimers(ViewDate);
    }

    void FetchTimers(DateTime date)
    {
        Timers = new ObservableCollection<Models.Timer>(App.TimerRepository.GetAll());
        TimersToView = new ObservableCollection<TimerDTO>(Timers.Where(x => x.Date == date)
            .Select(x => new TimerDTO
            {
                Id = x.Id,
                Date = x.Date,
                Duration = x.Duration,
                CategoryId = x.CategoryId,
                CategoryName = Categories.Single(y => y.Id == x.CategoryId).Name
            }));
        TotalTime = new TimeSpan(TimersToView.Sum(x => x.Duration.Ticks));
    }

}
