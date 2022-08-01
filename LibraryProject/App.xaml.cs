using LibraryProject.Repository;

namespace LibraryProject;

public partial class App : Application
{
	public static DataReader DataReader { get; private set; }

	public App(DataReader db)
	{
		InitializeComponent();

		MainPage = new AppShell();

		DataReader = db;
	}
}
