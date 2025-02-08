using CommunityToolkit.Maui.Views;
using TODOAPP.Models;
using TODOAPP.ViewModels;

namespace TODOAPP;

public partial class NewTodoPopup : Popup
{
    private readonly ToDoViewModel _viewModel;

    public NewTodoPopup(ToDoViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
	}

    private void SaveTODOClicked(object sender, EventArgs e)
    {
        string importance = HighRadioButton.IsChecked ? "High" :
                            MediumRadioButton.IsChecked ? "Medium" : "Low";

        var newTodo = new ToDoItem
        {
            Title = TaskTitle.Text,
            Description = TaskDescription.Text,
            Importance = importance
        };

        _viewModel.AddTodo(newTodo);
        _viewModel.SaveTodos();
        Close();
    }
    private void CancelTODOClicked(object sender, EventArgs e)
    {
        Close();
    }
}