using Maui.Timer.ViewModels;
using Maui.Timer.Views;

namespace Maui.Timer;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void NavigateToBudget(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddTransaction(new AddTransactionViewModel()));
    }

    private void NavigateToSleep(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddSleep(new AddSleepViewModel()));
    }

    private void NavigateToUber(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddUber(new AddUberShiftViewModel()));
    }

    private void NavigateToTimers(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddTimer(new AddTimerViewModel()));
    }

    private void NavigateToExercise(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddExercise(new AddExerciseViewModel()));
    }
}

