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
        _viewModel.LoadTodos();
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
        viewModel.SaveTodos();
    }


    private void OnDeletePointerEntered(object sender, PointerEventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#cf0c19");
    }

    private void OnDeletePointerExited(object sender, PointerEventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#f51423");
    }

    private void OnAddPointerEntered(object sender, PointerEventArgs e) 
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#02c70f");
    }

    private void OnAddPointerExited(object sender, PointerEventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#72f763");
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _viewModel.SaveTodos();
    }
}