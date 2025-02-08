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

    private void OnSavePointerEntered(object sender, PointerEventArgs e) //change color on hover
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#02c70f");
    }

    private void OnSavePointerExited(object sender, PointerEventArgs e) //change color back from hover
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#72f763");
    }

    private void OnCancelPointerEntered(object sender, PointerEventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#c4101c");
    }

    private void OnCancelPointerExited(object sender, PointerEventArgs e) 
    {
        var button = sender as Button;
        button.BackgroundColor = Color.FromArgb("#fc584c");
    }
}