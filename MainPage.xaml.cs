using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace xamplify
{
    public partial class MainPage : ContentPage
    {
        private Image CloseImage;

        public MainPage()
        {
            InitializeComponent();
            ShowSplashScreen();

            // Add tap gesture to the entire content area
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnScreenEdgeTapped;
            Demo.GestureRecognizers.Add(tapGestureRecognizer); // Add to your specific layout or view

#if WINDOWS
            // Create CloseImage and add tap gesture only for Windows
            CloseImage = new Image
            {
                Source = "closeimage.png",
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            var closeImageTapGestureRecognizer = new TapGestureRecognizer();
            closeImageTapGestureRecognizer.Tapped += OnCloseImageTapped;
            CloseImage.GestureRecognizers.Add(closeImageTapGestureRecognizer);

            // Add CloseImage to your layout
            Demo.Children.Add(CloseImage);
#endif
        }

        private async void ShowSplashScreen()
        {
            // Check if the current platform is Windows
            if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
            {
                // Load the splash screen for Windows
                Content = new Image { Source = "splashwindows.png", Aspect = Aspect.AspectFill };
                await Task.Delay(5000); // Adjust the duration as needed
            }

            MyWebView.Source = new Uri("https://xamplify.io");
            Content = Demo;

#if WINDOWS
            // Add null check for CloseImage to avoid potential NullReferenceException
            if (CloseImage != null)
            {
                CloseImage.IsVisible = false;
            }
#endif
        }

        private void OnScreenEdgeTapped(object sender, EventArgs e)
        {
            // Ensure the correct event args type and handle null reference
            if (e is TappedEventArgs tappedEventArgs)
            {
                // Get the Y coordinate of the tap
                Point? windowPosition = tappedEventArgs.GetPosition(null);
                double tapY = windowPosition?.Y ?? 0;

                // Check if the tap is near the top edge (adjust the threshold as needed)
                if (tapY < 30)
                {
#if WINDOWS
                    // Add null check for CloseImage to avoid potential NullReferenceException
                    if (CloseImage != null)
                    {
                        // Toggle the visibility of the CloseImage
                        CloseImage.IsVisible = !CloseImage.IsVisible;
                    }
#endif
                }
            }
        }

        private async void OnCloseImageTapped(object sender, EventArgs e)
        {
            await OnCloseAppClicked();
        }

        private async Task OnCloseAppClicked()
        {
            // Your logic for closing the application
            bool shouldClose = await DisplayAlert("Confirm", "Are you sure you want to close the application?", "Yes", "No");

            if (shouldClose)
            {
                // Replace this with the actual way to close the app on your platform
                (Application.Current as App)?.Quit();
            }
            else
            {
#if WINDOWS
                // Add null check for CloseImage to avoid potential NullReferenceException
                if (CloseImage != null)
                {
                    CloseImage.IsVisible = false;
                }
#endif
            }
        }
    }
}
