using Coffee.Models;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class SelectedItemViewModel : BaseViewModel
    {
        public ObservableCollection<Drink> Drinks { get; set; } = new ObservableCollection<Drink>();
    }
}
