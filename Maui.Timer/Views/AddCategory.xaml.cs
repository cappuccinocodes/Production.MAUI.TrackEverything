using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class AddCategory : ContentPage
{
	public AddCategory(AddCategoryViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}