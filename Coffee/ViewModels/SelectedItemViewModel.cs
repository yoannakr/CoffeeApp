using Coffee.Models;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class SelectedItemViewModel : BaseViewModel
    {
        private ObservableCollection<Drink> drinks;
        private ObservableCollection<Extra> extras;

        public ObservableCollection<Drink> Drinks
        {
            get
            {
                if (drinks == null)
                    drinks = new ObservableCollection<Drink>();

                return drinks;
            }
        }

        public ObservableCollection<Extra> Extras
        {
            get
            {
                if (extras == null)
                    extras = new ObservableCollection<Extra>();

                return extras;
            }
        }

        public decimal CurrentSum { get; set; }
    }
}
