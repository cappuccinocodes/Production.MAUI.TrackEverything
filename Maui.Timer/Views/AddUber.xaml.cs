using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddUber : ContentPage
{
	public AddUber(AddUberShiftViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}