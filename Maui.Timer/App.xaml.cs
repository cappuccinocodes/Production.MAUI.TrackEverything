using Maui.Timer.Data;

namespace Maui.Timer;

public partial class App : Application
{
    public static BudgetRepository BudgetRepository { get; private set; }
    public static SleepRepository SleepRepository { get; private set; }
    public static UberRepository UberRepository { get; private set; }

    public App(
		BudgetRepository budgetRepository, 
		SleepRepository sleepRepository,
		UberRepository uberRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BudgetRepository = budgetRepository;
		SleepRepository = sleepRepository;
		UberRepository = uberRepository;
	}
}
