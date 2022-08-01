using LibraryProject.Models;

namespace LibraryProject;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        InitializeComponent();
    }

	public async void OnLoginButtonClicked(object sender, EventArgs e)
	{

		string username = LoginUsername.Text;
		string password = LoginPassword.Text;

		List<User> users = App.DataReader.GetUsers(); // Is loading all users into memory a sin in real world applications

		bool isSuccessfulLogin = false;

        foreach (var user in users)
		{
			if (user.Username == username && user.Password == password)
			{
				isSuccessfulLogin = true;
				App.DataReader.ReplaceCurrentUser(username);
				await Navigation.PushAsync(new BranchSelectionPage());
				break;
			}
		}

        if (!isSuccessfulLogin)
		{
			await DisplayAlert("Login Failed", "Invalid username and password combination, please try again.", "OK");
		}
	}

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}

	private async void OnAdminButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AdminRegistrationPage());
	}
}

