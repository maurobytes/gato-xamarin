using Acr.UserDialogs;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TicTacToe
{
    public class HistoryViewModel : ViewModelBase
    {
        public HistoryViewModel(Page page) :base(page)
        {
            Items = new ObservableRangeCollection<Game>();
            RefreshDataCommand = new Command(
              async () => await RefreshData());
        }

        public ObservableRangeCollection<Game> Items { get; }
     

        public ICommand RefreshDataCommand { get; }

        async Task RefreshData()
        {
            IsBusy = true;
            var progress = UserDialogs.Instance.Loading("Cargando historial...", maskType: MaskType.Gradient);
            try
            {
                var items = await DependencyService.Get<AzureService>().GetGames();
                Items.ReplaceRange(items);
            }
            catch(Exception ex)
            {
                await UserDialogs.Instance.AlertAsync("No pudimos obtener el historial, prueba de nuevo.");
                return;
            }
            finally
            {
                progress.Hide();
                IsBusy = false;
            }

            if(Items.Count == 0)
                await UserDialogs.Instance.AlertAsync("Aún no haz jugado, que esperas?!", "Sin historial");
        }


    }
}
