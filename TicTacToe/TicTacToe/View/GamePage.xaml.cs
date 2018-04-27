using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TicTacToe.View
{
	public partial class GamePage : ContentPage
	{
		public GamePage ()
		{
			InitializeComponent ();
            BindingContext = new GameViewModel(this);
            Title = $"{Settings.Current.Player1} vs. {Settings.Current.Player2}";
            Analytics.TrackEvent("Navigation", new Dictionary<string, string>
            {
                ["Page"] = "Juego"
            });
        }

        protected override bool OnBackButtonPressed()
        {
            UserDialogs.Instance.ConfirmAsync("¿Estás seguro de que deseas abandonar el juego actual?", "Abandonar juego").ContinueWith((exit) =>
            {
                if (exit.Result)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                    });
                }
            });

            return true;
        }
    }
}
