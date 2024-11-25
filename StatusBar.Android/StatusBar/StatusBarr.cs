using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.CurrentActivity;
using StatusBar.Droid.StatusBar;
using StatusBar.ViewModel;
using Xamarin.Forms;

[assembly:Dependency(typeof(StatusBarr))]

namespace StatusBar.Droid.StatusBar
{
    internal class StatusBarr : VMStatusBar
    {
        WindowManagerFlags _originalFlags;
        Window GetCrurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }

        public void CambiarColor()
        {
            MostarStatusBar();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCrurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(18, 18, 18));
                });
            }
        }

        public void MostarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        public void OcultarStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        public void Transparente()
        {
            MostarStatusBar();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCrurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
                });
            }
        }

        public void Traslucido()
        {
            MostarStatusBar();
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags |= WindowManagerFlags.TranslucentStatus;
            activity.Window.Attributes = attrs;
        }
    }
}