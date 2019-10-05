using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KQ.Droid.Services;
using KQ.Xamarin.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarStyleManager))]
namespace KQ.Droid.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {

        #region MÉTODOS PÚBLICOS

        public void SetDarkTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //var currentWindow = getCurrentWindow();
                    //currentWindow.DecorView.SystemUiVisibility = 0;
                    //Window.
                    //Window.SetStatusBarColor(Android.Graphics.Color.DarkGray);
                });
            }
        }

        public void SetLightTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = getCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.White);
                });
            }
        }

        #endregion MÉTODOS PÚBLICOS

        #region MÉTODOS PRIVADOS

        private Window getCurrentWindow()
        {

            

            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }

        #endregion MÉTODOS PRIVADOS
    }
}