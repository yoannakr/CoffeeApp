using Coffee.Models;
using Coffee.DataSettings.Implementations;
using System.Collections.ObjectModel;
using static Coffee.DataSettings.DataSetting;
using Coffee.DataSettings;

namespace Coffee.ViewModels
{
    public class DrinkViewModel : BaseViewModel
    {
        private static readonly IReader xml = new XmlReader();

        public ObservableCollection<Drink> Drinks { get; } = xml.ReadData<Drink>(DrinksXml);


    }
}
