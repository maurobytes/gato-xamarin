using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Acr.UserDialogs;
using Microsoft.AppCenter;

namespace TicTacToe.Droid
{
	[Activity (Label = "Gato", 
        Icon = "@drawable/icon", 
        MainLauncher = true, 
        ConfigurationChanges = 
        ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate (bundle);

			Forms.Init (this, bundle);
            AppCenter.Start("4e3c9310-9aec-4414-b0f6-0557e326cada");
            LoadApplication (new App ());

            UserDialogs.Init(this);
		}
	}
}

