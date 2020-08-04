using Coffee.Models;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class SelectedItemViewModel : BaseViewModel
    {
        private ObservableCollection<DrinkViewModel> drinks;
        private decimal currentSum;

        public ObservableCollection<DrinkViewModel> Drinks
        {
            get
            {
                if (drinks == null)
                    drinks = new ObservableCollection<DrinkViewModel>();

                return drinks;
            }
        }

        public decimal CurrentSum
        {
            get => this.currentSum;
            set
            {
                this.currentSum = value;
                OnPropertyChanged("CurrentSum");
            }
        }

        public DrinkViewModel Drink { get; set; }

    }
}
