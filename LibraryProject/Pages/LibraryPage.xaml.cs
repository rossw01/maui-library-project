using LibraryProject.Models;

namespace LibraryProject;

public partial class LibraryPage : ContentPage
{
	public readonly SelectableBranch _currentBranch;
	public LibraryPage(SelectableBranch selectedBranch)
	{
		InitializeComponent();

		_currentBranch = selectedBranch;

	}
	public async void OnTestButtonClick(object sender, EventArgs e)
	{
		await DisplayAlert("123",$"{_currentBranch.Name}","OK");
	}
}