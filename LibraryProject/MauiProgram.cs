using LibraryProject.Repository;

namespace LibraryProject;

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

		string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "users.db3");
		builder.Services.AddSingleton<DataReader>(s => ActivatorUtilities.CreateInstance<DataReader>(s, dbPath));

        return builder.Build();
	}
}
