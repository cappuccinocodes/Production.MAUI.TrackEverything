using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddSleepViewModel: ObservableObject
{
    public AddSleepViewModel()
    {
        FetchSleeps();
    }

    [ObservableProperty]
    ObservableCollection<Sleep> sleeps;

    [ObservableProperty]
    ObservableCollection<SleepDTO> sleepsToView;

    [ObservableProperty]
    DateTime dateStart;

    [ObservableProperty]
    TimeSpan timeStart;

    [ObservableProperty]
    DateTime dateEnd;

    [ObservableProperty]
    TimeSpan timeEnd;

    [RelayCommand]
    async Task Add()
    {
        try
        {
            App.SleepRepository.Add(new Sleep
            {
                DateStart = dateStart.AddTicks(timeStart.Ticks),
                DateEnd = dateEnd.AddTicks(timeEnd.Ticks),
            });

            FetchSleeps();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.SleepRepository.Delete(id);
        FetchSleeps();
    }

    void FetchSleeps()
    {
        Sleeps = new ObservableCollection<Sleep>(App.SleepRepository.GetAll());
        SleepsToView = new ObservableCollection<SleepDTO>(Sleeps.Select(x =>
           new SleepDTO { 
               Id = x.Id,
               DateStart = x.DateStart, 
               DateEnd = x.DateEnd 
           }));
    }
}
