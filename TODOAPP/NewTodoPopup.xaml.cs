using CommunityToolkit.Maui.Views;

namespace TODOAPP;

public partial class NewTodoPopup : Popup
{
	public NewTodoPopup()
	{
		InitializeComponent();
	}

    private void SaveTODOClicked(object sender, EventArgs e)
    {

    }
    private void CancelTODOClicked(object sender, EventArgs e)
    {
        Close();
    }
}