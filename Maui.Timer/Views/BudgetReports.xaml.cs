using Maui.Timer.ViewModels;

namespace Maui.Timer.Views;

public partial class BudgetReports : ContentPage
{
	public BudgetReports(BudgetReportsViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}