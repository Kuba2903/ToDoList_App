using CommunityToolkit.Maui.Views;

namespace TODOAPP;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void CreateBtn_Clicked(object sender, EventArgs e)
    {
		var popup = new NewTodoPopup();
		await this.ShowPopupAsync(popup);
    }
}