using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddTimer : ContentPage
{
	public AddTimer(AddTimerViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}