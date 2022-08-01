namespace LibraryProject;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnBackButtonClick(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	private async void RegisterButtonClick(object sender, EventArgs e)
	{
		string[] details = {RegisterUsername.Text, RegisterPassword.Text, RegisterPasswordConfirm.Text};

		if (!details.Any(str => string.IsNullOrEmpty(str))) // checks none of the fields are null or empty
		{
			CheckNewLoginDetails(details[0], details[1], details[2]);
		}
		else
		{
			await DisplayAlert("Registration Failed", "None of the input fields can be left empty.", "OK");
		}
	}

	private async void CheckNewLoginDetails(string username, string pass, string passConfirm) // checks login details
	{
		bool registrationFailed = false;

        if (username.Length < 6)
        {
            await DisplayAlert("Invalid username choice!", "The username must be at least 6 characters in length. Please try again.", "OK");
            registrationFailed = true;
        }

        else if (!(pass.Any(c => char.IsDigit(c)) && pass.Length >= 6)) // checks for number in pw and makes sure pw >= 6 chars
		{
			await DisplayAlert("Invalid password choice!", "The password must be at least 6 characters in length and must contain a number, please try again.", "OK");
			registrationFailed = true;
		}
		else if (pass != passConfirm) // else if prevents end user receiving multiple alerts and getting bombarded
		{
			await DisplayAlert("Passwords do not match!", "The passwords you entered did not match, please double check your password and password confirmation.", "OK");
            registrationFailed = true;
        }

		if (!registrationFailed) // if none of the previous test cases were triggered...
		{
			try
			{
				AddNewUser(username, pass);
			}
			catch
			{
				await DisplayAlert("Account creation failed",
					$"The username '{username}' is already in use, please try again with a different username", "OK");
			}
		}
	}
	private void AddNewUser(string username, string pass)
	{
		App.DataReader.AddNewUser(username, pass, false); //false sets 'IsAdmin' to false
        AccountCreationSuccessAlert(username);
	}

	private async void AccountCreationSuccessAlert(string newUsername)
	{
		await DisplayAlert("Success!", $"Your account '{newUsername}' has been created!", "OK");
	}
}