using System;
using System.Windows;
using Prism.Commands;
using Coffee.Models;
using Coffee.Enums;
using System.Windows.Input;
using Coffee.DataSettings;
using Coffee.DataSettings.Implementations;
using System.Collections.ObjectModel;
using static Coffee.DataSettings.DataSetting;

namespace Coffee.ViewModels
{
    public class DrinkViewModel : BaseViewModel
    {
        private ICommand addDrinkCommand;
        private readonly IReader xml = new XmlReader();

        public int Count { get; set; }

        public Drink Drink { get; set; }

        public DrinkSizeEnum DrinkSize { get; set; }

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
            if (Drink == null)
            {
                MessageBox.Show("Please choose drink!");
            }
            else if (Count <= 0 || Count > 10)
            {
                MessageBox.Show("Please enter count between 1 and 10!");
            }
            else if (!Enum.IsDefined(typeof(DrinkSizeEnum), DrinkSize))
            {
                MessageBox.Show("Please choose size!");
            }

            decimal sizePrice = (decimal)DrinkSize / 100;
            MessageBox.Show($"{Drink.Name} {Count} {DrinkSize} {Count * (Drink.Price + sizePrice)}");
        }
    }
}
