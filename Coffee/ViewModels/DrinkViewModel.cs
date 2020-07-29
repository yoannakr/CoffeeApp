using Prism.Commands;
using Coffee.Models;
using System.Windows.Input;
using Coffee.DataSettings;
using Coffee.DataSettings.Implementations;
using System.Collections.ObjectModel;
using static Coffee.DataSettings.DataSetting;
using System;

namespace Coffee.ViewModels
{
    public class DrinkViewModel : BaseViewModel
    {
        private ICommand addDrinkCommand;
        private readonly IReader xml = new XmlReader();

        public int Count { get; set; }

        public string DrinkName { get; set; }

        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
        }

        public ICommand AddDrinkCommand
        {
            get
            {
                if (addDrinkCommand == null)
                    addDrinkCommand = new DelegateCommand<object>(AddDrinkToSelectedItem);

                return addDrinkCommand;
            }
        }

        private void AddDrinkToSelectedItem(object obj)
        {

        }
    }
}
