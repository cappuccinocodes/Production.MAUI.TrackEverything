using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddTransaction : ContentPage
{
	public AddTransaction(AddTransactionViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}