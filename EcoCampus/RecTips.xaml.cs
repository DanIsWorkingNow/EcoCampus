namespace EcoCampus
{
    public partial class RecTips : ContentPage
    {
        public RecTips()
        {
            InitializeComponent();
        }

        // Event handler for the Back to Main Page button
        async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            // Navigate to the MainPage
            await Navigation.PushAsync(new MainPage());
        }
    }
}