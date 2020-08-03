using Coffee.Models;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class SelectedItemViewModel : BaseViewModel
    {
        private ObservableCollection<DrinkViewModel> drinks;

        public ObservableCollection<DrinkViewModel> Drinks
        {
            get
            {
                if (drinks == null)
                    drinks = new ObservableCollection<DrinkViewModel>();

                return drinks;
            }
        }

        public decimal CurrentSum { get; set; }

        public DrinkViewModel Drink { get; set; }
    }
}
