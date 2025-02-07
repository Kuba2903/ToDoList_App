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
            await Navigation.PushAsync(new HomePage());
        }

        private async void AboutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }

}
