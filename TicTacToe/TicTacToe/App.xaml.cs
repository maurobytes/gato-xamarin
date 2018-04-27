using TicTacToe.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]

namespace TicTacToe
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            AppCenter.Start(typeof(Analytics), typeof(Crashes));

            MainPage = new NavigationPage(new HomePage())
            {
                BarBackgroundColor = Color.FromHex("#2196F3"),
                BarTextColor = Color.White
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
