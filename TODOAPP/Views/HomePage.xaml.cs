using CommunityToolkit.Maui.Views;
using TODOAPP.ViewModels;

namespace TODOAPP;

public partial class HomePage : ContentPage
{
	private readonly ToDoViewModel _viewModel;
	public HomePage(ToDoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

    private async void CreateBtn_Clicked(object sender, EventArgs e)
    {
		var popup = new NewTodoPopup(_viewModel);
		await this.ShowPopupAsync(popup);
    }
}