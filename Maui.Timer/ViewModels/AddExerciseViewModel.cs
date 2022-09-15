using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Timer.Models;
using System.Collections.ObjectModel;

namespace Maui.Timer.ViewModels;

public partial class AddExerciseViewModel: ObservableObject
{
    public List<int> pickerRange = Enumerable.Range(0, 59).ToList();

    public AddExerciseViewModel()
    {
        PrepareForm();
    }

    private void PrepareForm()
    {
        Date = DateTime.Today;
        NumbersForPicker = new ObservableCollection<int>(pickerRange);
    }

    [ObservableProperty]
    ObservableCollection<int> numbersForPicker;

    [ObservableProperty]
    ObservableCollection<Exercise> exercises;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    string type;

    #region Reps
    [ObservableProperty]
    int repetitions1;
    [ObservableProperty]
    int repetitions2;
    [ObservableProperty]
    int repetitions3;
    [ObservableProperty]
    int repetitions4;
    #endregion 

    #region Duration
    [ObservableProperty]
    TimeSpan duration1;
    [ObservableProperty]
    TimeSpan duration2;
    [ObservableProperty]
    TimeSpan duration3;
    [ObservableProperty]
    TimeSpan duration4;
    #endregion

    #region Intensity
    [ObservableProperty]
    decimal intensity1;
    [ObservableProperty]
    decimal intensity2;
    [ObservableProperty]
    decimal intensity3;
    [ObservableProperty]
    decimal intensity4;
    #endregion

    #region Distance
    [ObservableProperty]
    decimal distance1;
    [ObservableProperty]
    decimal distance2;
    [ObservableProperty]
    decimal distance3;
    [ObservableProperty]
    decimal distance4;
    #endregion

    [RelayCommand]
    async Task Add()
    {
        try
        {
            App.ExerciseRepository.Add(new Exercise
            {
                Date = Date,
                Type = Type,
                Duration1 = Duration1,
                Duration2 = Duration2,
                Duration3 = Duration3,
                Duration4 = Duration4,
                Repetitions1 = Repetitions1,
                Repetitions2 = Repetitions2,
                Repetitions3 = Repetitions3,
                Repetitions4 = Repetitions4,
                Intensity1 = Intensity1,
                Intensity2 = Intensity2,
                Intensity3 = Intensity3,
                Intensity4 = Intensity4,
                Distance1 = Distance1,
                Distance2 = Distance2,
                Distance3 = Distance3,
                Distance4 = Distance4,
            });

            PopulateList();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    void PopulateList()
    {
        Exercises = new ObservableCollection<Exercise>(App.ExerciseRepository.GetAll());
    }

    [RelayCommand]
    void Delete(int id)
    {
        App.ExerciseRepository.Delete(id);

        PopulateList();
    }

    [RelayCommand]
    async Task PopulateForm(Exercise exercise)
    {
        Type = exercise.Type;
        Date = exercise.Date;
    }

}
