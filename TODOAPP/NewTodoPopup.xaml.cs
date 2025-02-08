using CommunityToolkit.Maui.Views;

namespace TODOAPP;

public partial class NewTodoPopup : Popup
{
    public Action<string?, string?, string?> OnToDoAdded;

	public NewTodoPopup()
	{
		InitializeComponent();
	}

    private void SaveTODOClicked(object sender, EventArgs e)
    {
        string? title = TaskTitle.Text?.Trim() ?? null;
        string? description = TaskDescription.Text?.Trim() ?? null;
        string? importance = HighRadioButton.IsChecked ? "High" : 
            MediumRadioButton.IsChecked ? "Medium" : LowRadioButton.IsChecked ? "Low" : "Not selected";

        if (!string.IsNullOrEmpty(title))
        {
            OnToDoAdded?.Invoke(title, description, importance);
            Close();
        }


    }
    private void CancelTODOClicked(object sender, EventArgs e)
    {
        Close();
    }
}