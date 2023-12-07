namespace xamplify
{
    public partial class MainPage : ContentPage
    {
        private Image Closeimage;  

        public MainPage()
        {
            InitializeComponent();
            ShowSplashScreen();

            // Add tap gesture to the entire content area
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnScreenEdgeTapped;
            Demo.GestureRecognizers.Add(tapGestureRecognizer); // Add to your specific layout or view

            // Create Closeimage and add tap gesture
            Closeimage = new Image
            {
                Source = "closeimage.png",
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            var closeImageTapGestureRecognizer = new TapGestureRecognizer();
            closeImageTapGestureRecognizer.Tapped += OnCloseImageTapped;
            Closeimage.GestureRecognizers.Add(closeImageTapGestureRecognizer);

            // Add Closeimage to your layout
            Demo.Children.Add(Closeimage);

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
            Closeimage.IsVisible = false;
        }

        private void OnScreenEdgeTapped(object sender, EventArgs e)
        {
            var tappedEventArgs = e as TappedEventArgs;

            if (tappedEventArgs != null)
            {
                // Get the Y coordinate of the tap
                Point? windowPosition = tappedEventArgs.GetPosition(null);
                double tapY = windowPosition?.Y ?? 0;

                // Check if the tap is near the top edge (adjust the threshold as needed)
                if (tapY < 30)
                {
                    // Toggle the visibility of the Closeimage
                    Closeimage.IsVisible = !Closeimage.IsVisible;
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
                Closeimage.IsVisible = false;
            }
        }
    }
}
