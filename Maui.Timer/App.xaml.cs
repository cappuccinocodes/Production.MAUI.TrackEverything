using Maui.Timer.Data;

namespace Maui.Timer;

public partial class App : Application
{
    public static BudgetRepository BudgetRepository { get; private set; }
    public static SleepRepository SleepRepository { get; private set; }
    public static UberRepository UberRepository { get; private set; }
    public static TimerRepository TimerRepository { get; private set; }
    public static ExerciseRepository ExerciseRepository { get; private set; }

    public App(
		BudgetRepository budgetRepository, 
		SleepRepository sleepRepository,
		UberRepository uberRepository,
        TimerRepository timerRepository,
		ExerciseRepository exerciseRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BudgetRepository = budgetRepository;
		SleepRepository = sleepRepository;
		UberRepository = uberRepository;
		TimerRepository = timerRepository;
		ExerciseRepository = exerciseRepository;
	}
}
