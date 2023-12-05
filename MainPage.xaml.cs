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
            // Simulate a delay to show the splash screen for a few seconds
            await Task.Delay(5000); // Adjust the duration as needed


            // Set the ContentView to an Image displaying the splash screen
            Content = new Image { Source = "splashwindows.png", Aspect = Aspect.AspectFill };

            // Initialize the WebView
            MyWebView = new WebView
            {
                Source = new Uri("https://xamplify.io/")
            };

            // Set the ContentView to the WebView
            Content = MyWebView;
        }
    }
}


