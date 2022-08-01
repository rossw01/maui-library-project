namespace LibraryProject;
public partial class AdminRegistrationPage : ContentPage
{
	public AdminRegistrationPage()
	{
		InitializeComponent();
	}

	private async void DeleteAllUsers(object sender, EventArgs e)
	{
		App.DataReader.ClearDatabase();
		await DisplayAlert("Database Cleared", "Contents of 'Users' database cleared successfully","OK");
	}

	private async void RegisterButtonClicked(object sender, EventArgs e)
	{
		if (!(string.IsNullOrEmpty(AdminUsernameEntry.Text) && string.IsNullOrEmpty(AdminPasswordEntry.Text)))
		{
			string username = AdminUsernameEntry.Text;
			string password = AdminPasswordEntry.Text;

			if (username.Length >= 6 && password.Length >= 6 && password.Any(c => char.IsDigit(c)))
			{
                try
                {
                    App.DataReader.AddNewUser(username, password, true);
					await DisplayAlert("Account creation successful", $"The admin account '{username}' was created successfully.", "OK");
                }
                catch
                {
                    await DisplayAlert("Account creation failed", $"The username '{username}' is already in use, please try again with a different username.", "OK");
                }
			}
			else
			{
				await DisplayAlert("Account creation failed", "The username or password you entered did not meet the requirements.", "OK");
			}
        }
	}
}