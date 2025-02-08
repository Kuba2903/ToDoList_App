using CommunityToolkit.Maui.Views;
using TODOAPP.Models;
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

    private void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var todoItem = (ToDoItem)button.CommandParameter;

        var viewModel = (ToDoViewModel)BindingContext;

        viewModel.RemoveTodo(todoItem);
    }
}