using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace xamplify
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        private void SetWindowLayout()
        {
            if (Window != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
                {
                    IWindowInsetsController wicController = Window.InsetsController;

                    Window.SetDecorFitsSystemWindows(false);
                    Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                    if (wicController != null)
                    {
                        wicController.Hide(WindowInsets.Type.Ime());
                        wicController.Hide(WindowInsets.Type.NavigationBars());
                    }
                }
                else
                {
                    Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.Fullscreen |
                                                                                 SystemUiFlags.HideNavigation |
                                                                                 SystemUiFlags.Immersive |
                                                                                 SystemUiFlags.ImmersiveSticky |
                                                                                 SystemUiFlags.LayoutHideNavigation |
                                                                                 SystemUiFlags.LayoutStable |
                                                                                 SystemUiFlags.LowProfile);
                }
            }
        }

        protected override void OnCreate(Bundle bSavedInstanceState)
        {
            base.OnCreate(bSavedInstanceState);

            SetWindowLayout();
        }

        public override void OnBackPressed()
        {
            // Simply close the app without showing a confirmation dialog
            FinishAffinity();
        }
    }
}
