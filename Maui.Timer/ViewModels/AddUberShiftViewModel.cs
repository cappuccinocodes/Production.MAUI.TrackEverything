using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddUberShiftViewModel : ObservableObject
{
    public AddUberShiftViewModel()
    {
        FetchShifts();
    }

    [ObservableProperty]
    ObservableCollection<UberShift> shifts;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    TimeSpan duration;


    [ObservableProperty]
    decimal amount;

    [RelayCommand]
    async Task Add()
    {
        try
        {
            App.UberRepository.Add(new UberShift
            {
                Date = date,
                Duration = duration,
                Amount = amount
            });

            FetchShifts();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.UberRepository.Delete(id);
        FetchShifts();
    }

    void FetchShifts()
    {
        Shifts = new ObservableCollection<UberShift>(App.UberRepository.GetAll());
    }
}
