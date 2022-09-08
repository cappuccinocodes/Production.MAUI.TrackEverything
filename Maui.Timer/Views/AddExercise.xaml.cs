using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddExercise : ContentPage
{
	public AddExercise(AddExerciseViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}