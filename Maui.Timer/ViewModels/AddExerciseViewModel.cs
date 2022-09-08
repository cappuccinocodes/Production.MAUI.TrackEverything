using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddExerciseViewModel: ObservableObject
{
    public List<int> SetsList = Enumerable.Range(1, 100).ToList();
    public List<int> RepsList = Enumerable.Range(1, 1000).ToList();

    public AddExerciseViewModel()
    {
        PrepareForm();
    }

    private void PrepareForm()
    {
        SetsForPicker = new ObservableCollection<int>(SetsList);
        RepsForPicker = new ObservableCollection<int>(RepsList);
        Date = DateTime.Today;
    }

    [ObservableProperty]
    ObservableCollection<int> setsForPicker;

    [ObservableProperty]
    ObservableCollection<int> repsForPicker;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    TimeSpan duration;

    [ObservableProperty]
    string type;

    [ObservableProperty]
    string sets;

    [ObservableProperty]
    decimal intensity;

    [ObservableProperty]
    decimal distance;

    [RelayCommand]
    async Task Add()
    {
      
    }

    [RelayCommand]
    void Delete(int id)
    {
        
    }

}
