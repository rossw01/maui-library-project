using System.Security.AccessControl;

namespace LibraryProject;

public partial class AddBranchPage : ContentPage
{
	public AddBranchPage()
	{
		InitializeComponent();
	}

    Stream imageDataStream;

    private async void BranchPhotoSelection(object sender, EventArgs e)
    {
        FileResult selectedFile;

        try
        {
            selectedFile = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images, // only images can be uploaded
                PickerTitle = "Upload an image..."
            });
        }
        catch
        {
            return;
        }

        if (selectedFile != null)
        {
            Stream stream = await selectedFile.OpenReadAsync();
            selectedImage.Source = ImageSource.FromStream(() => stream);

            imageDataStream = await selectedFile.OpenReadAsync();
        }
	}

    private async void OnCreateBranchClick(object sender, EventArgs e)
    {
        byte[] imageData = DataStreamToByteArray(imageDataStream);
        string branchName = NewBranchNameEntry.Text;

        if (!(string.IsNullOrEmpty(branchName)) && branchName.Length >= 4)
        {
            try
            {
                App.DataReader.AddNewBranch(branchName, imageData);
                await DisplayAlert("Branch created.",
                    $"The new branch '{branchName}' was created successfully!", "OK");

                var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
                await Navigation.PushAsync(new BranchSelectionPage());
                Navigation.RemovePage(previousPage);

                /*
                
                Navigation.RemovePage(Navigation.NavigationStack.LastOrDefault());
                await Navigation.PushAsync(new BranchSelectionPage());
                */

            }
            catch
            {
                await DisplayAlert("Error creating new branch.",
                    "A branch with that name already exists. Please try again with a different name.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error creating new branch.",
                "The name you chose was too short, please choose a name of at least 4 characters in length.", "OK");
        }

    }

    public byte[] DataStreamToByteArray(Stream imageDataStream)
    {
        if (imageDataStream != null)
        { 
            using (var ms = new MemoryStream()) {
                imageDataStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
        else
        {
            return null; // Allows user the option to not have any picture associated with the branch upon creation
        }
    }

    public async void OnCancelButtonClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}