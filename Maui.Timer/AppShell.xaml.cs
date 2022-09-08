using Maui.Timer.Views;

namespace Maui.Timer;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(AddTransaction), typeof(AddTransaction));
        Routing.RegisterRoute(nameof(AddCategory), typeof(AddCategory));
        Routing.RegisterRoute(nameof(BudgetReports), typeof(BudgetReports));
        Routing.RegisterRoute(nameof(AddSleep), typeof(AddSleep));
        Routing.RegisterRoute(nameof(AddUber), typeof(AddUber));
        Routing.RegisterRoute(nameof(AddTimer), typeof(AddTimer));
        Routing.RegisterRoute(nameof(AddExercise), typeof(AddExercise));
    }
}
