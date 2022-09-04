using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddSleep : ContentPage
{
    public AddSleep(AddSleepViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}