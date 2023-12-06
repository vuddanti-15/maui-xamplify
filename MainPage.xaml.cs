using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

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

            MyWebView.Source = new Uri("https://xamplify.io/");
            Content = Demo;
        }

        private void OnScreenEdgeTapped(object sender, EventArgs e)
        {
            // Handle the tap event for the screen edge
            // This will be triggered when the user taps anywhere on the button or the screen edge
            HandleLeftEdgeTap();
        }

        private void HandleLeftEdgeTap()
        {
            // Your logic for handling the tap near the left edge
            // For example, navigate to a new page, open a menu, etc.
            OnCloseAppClicked();
        }

        private async void OnCloseAppClicked()
        {
            // Your logic for closing the application
            bool shouldClose = await DisplayAlert("Confirm", "Are you sure you want to close the application?", "Yes", "No");

            if (shouldClose)
            {
                (Application.Current as App)?.Quit();
            }
        }
    }
}
