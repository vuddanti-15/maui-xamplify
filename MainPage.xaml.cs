
namespace xamplify
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ShowSplashScreen();
        }

        private async void ShowSplashScreen()
        {
            // Check if the current platform is Windows
            if (Device.RuntimePlatform == Device.WinUI)
            {
                // Load the splash screen for Windows
                Content = new Image { Source = "splashwindows.png", Aspect = Aspect.AspectFill };
                await Task.Delay(5000); // Adjust the duration as needed
            }

            // Initialize the WebView
            MyWebView = new WebView
            {
                Source = new Uri("https://xamplify.io/")
            };

            // Set the ContentView to the WebView
            Content = MyWebView;
        }
        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            // Close the app
            // Note: The behavior may vary depending on the platform
            // On some platforms, you may need to use specific APIs to close the app
            // For simplicity, you can use the following line, but check the platform-specific behavior
            App.Current.MainPage?.Navigation.PopModalAsync();
        }
    }
}
