using LibraryProject.Models;
using LibraryProject.ViewModels;
using System.Security.AccessControl;

namespace LibraryProject;

public partial class BranchSelectionPage : ContentPage
{
    public BranchSelectionPage()
	{		
        InitializeComponent();

		BindingContext = new BranchSelectionViewModel();

        AddBranchButton.IsVisible = App.DataReader.GetCurrentUser().IsAdmin; // Sets visibility of admin controls based on if user is an admin or not
    }

    public async void AddBranchButtonClick(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AddBranchPage());
    }

    public async void ImageSelectButtonClick(object sender, EventArgs e)
    {

		FileResult selectedFile = await FilePicker.PickAsync(new PickOptions
		{
			FileTypes = FilePickerFileType.Images,
			PickerTitle = "Upload an image..."
		});

		if (selectedFile != null)
		{
			Stream imageDataStream = await selectedFile.OpenReadAsync();
            DataStreamToByteArray(imageDataStream);
		}
	}

	public byte[] DataStreamToByteArray(Stream imageDataStream)
	{
		using (var ms = new MemoryStream())
		{
            imageDataStream.CopyTo(ms);
			return ms.ToArray();
		}
	}

    /*

	void CollectionViewListSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		string selectedBranchName = (e.CurrentSelection.FirstOrDefault() as Branch)?.BranchName;
	}
	*/

    SelectableBranch selectedBranch;

    public async void DeleteBranchButtonClick(object sender, EventArgs e)
	{
		//stackoverflow.com/questions/62522894 

		try
		{
            selectedBranch = (SelectableBranch)collectionView.SelectedItem;
        }
		catch
		{
			await DisplayAlert("Unable to delete branch", "No branch selection was made, select a branch first then try again", "OK");
			return;
		}

		bool deleteConfirmation = await DisplayAlert("Are you sure?", $"Are you sure you want to delete the branch '{selectedBranch.Name}'?","Yes","No"); 

		if (deleteConfirmation)
		{
			DeleteBranch(selectedBranch.ID);
		}
	}

	public async void EnterSelectedBranchButtonClick(object sender, EventArgs e)
	{
		try
		{
            selectedBranch = (SelectableBranch)collectionView.SelectedItem;
        }
		catch
		{
            await DisplayAlert("Error accessing Library Branch", "No library branch selection was made, please select a branch and try again.", "OK");
			return;
        }

		var libraryPage = new LibraryPage(selectedBranch);
		libraryPage.BindingContext = selectedBranch;

        await Navigation.PushAsync(libraryPage);
	}

	private async void DeleteBranch(int id)
	{
        App.DataReader.DeleteBranch(id);
        var previousPage = Navigation.NavigationStack.LastOrDefault(); // deletes then refreshes page, deletes old copy of page so user cant go back and accidentally visit old version of page.
        await Navigation.PushAsync(new BranchSelectionPage());
        Navigation.RemovePage(previousPage);
    }
}