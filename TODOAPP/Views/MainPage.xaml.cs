namespace TODOAPP
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage(new ViewModels.ToDoViewModel()));
        }

        private async void AboutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

        private void OnPointerEntered(object sender, PointerEventArgs e)
        {
            var button = sender as Button;
            button.BackgroundColor = Color.FromArgb("#93d1e6");
        }

        private void OnPointerExited(object sender, PointerEventArgs e)
        {
            var button = sender as Button;
            button.BackgroundColor = Color.FromArgb("#ADD8E6");
        }
    }

}
