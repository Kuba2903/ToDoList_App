using CommunityToolkit.Maui.Views;
using TODOAPP.Models;
using TODOAPP.ViewModels;

namespace TODOAPP;

public partial class NewTodoPopup : Popup
{
    private readonly ToDoViewModel _viewModel;

    private ToDoItem _editingItem;
    public NewTodoPopup(ToDoViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
	}

    public NewTodoPopup(ToDoItem item, ToDoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        //setting the forms inputs from editing model
        _editingItem = item;
        TaskTitle.Text = item.Title;
        TaskDescription.Text = item.Description;

        switch (item.Importance)
        {
            case "High":
                HighRadioButton.IsChecked = true;
                break;
            case "Medium":
                MediumRadioButton.IsChecked = true;
                break;
            case "Low":
                LowRadioButton.IsChecked = true;
                break;
        }
    }

    private void SaveTODOClicked(object sender, EventArgs e)
    {
        string importance = HighRadioButton.IsChecked ? "High" :
                            MediumRadioButton.IsChecked ? "Medium" : "Low";

        //editing mode
        if (_editingItem != null)
        {
            _editingItem.Title = TaskTitle.Text;
            _editingItem.Description = TaskDescription.Text;
            _editingItem.Importance = importance;
        }
        //adding new TODO mode
        else
        {
            var newTodo = new ToDoItem
            {
                Title = TaskTitle.Text,
                Description = TaskDescription.Text,
                Importance = importance
            };

            _viewModel.AddTodo(newTodo);
        }
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