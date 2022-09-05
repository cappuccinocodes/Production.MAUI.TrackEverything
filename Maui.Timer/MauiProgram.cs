using Maui.Timer.Data;
using Maui.Timer.ViewModels;
using Maui.Timer.Views;

namespace Maui.Timer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddTransient<AddTransaction>();
        builder.Services.AddTransient<AddTransactionViewModel>();

        builder.Services.AddTransient<AddCategory>();
        builder.Services.AddTransient<AddCategoryViewModel>();

		builder.Services.AddTransient<AddCategory>();
        builder.Services.AddTransient<AddCategoryViewModel>();

        builder.Services.AddTransient<BudgetReports>();
        builder.Services.AddTransient<BudgetReportsViewModel>();

        builder.Services.AddTransient<AddUber>();
        builder.Services.AddTransient<AddUberShiftViewModel>();

        builder.Services.AddTransient<AddTimer>();
        builder.Services.AddTransient<AddTimerViewModel>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "lifeManager.db");

        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<BudgetRepository>(s, dbPath));
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<SleepRepository>(s, dbPath));
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<UberRepository>(s, dbPath));
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<TimerRepository>(s, dbPath));


        return builder.Build();
	}
}
