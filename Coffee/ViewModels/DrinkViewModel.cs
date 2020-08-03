using System;
using System.Windows;
using Prism.Commands;
using Coffee.Models;
using Coffee.Enums;
using System.Windows.Input;
using Coffee.DataSettings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Coffee.DataSettings.Implementations;
using static Coffee.DataSettings.DataSetting;
using System.Linq;

namespace Coffee.ViewModels
{
    public class DrinkViewModel : BaseViewModel
    {
        private ICommand addDrinkCommand;
        private ObservableCollection<Extra> extras;
        private readonly IReader xml = new XmlReader();

        public DrinkViewModel(SelectedItemViewModel selected)
        {
            this.SelectedItemViewModel = selected;
        }

        public int Count { get; set; }

        public Drink Drink { get; set; }

        public DrinkSizeEnum DrinkSize { get; set; }

        public SelectedItemViewModel SelectedItemViewModel { get; }

        public decimal Total
        {
            get => this.Count * this.Drink.Price;
        }

        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
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
            if (!IsDrinkValid())
                return;

            SelectedItemViewModel.Drinks.Add(this);
            SelectedItemViewModel.HasItems = true;
        }

        private bool IsDrinkValid()
        {
            bool IsValid = true;

            if (Drink == null)
            {
                IsValid = false;
                MessageBox.Show("Please choose drink!");
            }
            else if (Count <= 0 || Count > 10)
            {
                IsValid = false;
                MessageBox.Show("Please enter count between 1 and 10!");
            }
            else if (!Enum.IsDefined(typeof(DrinkSizeEnum), DrinkSize))
            {
                IsValid = false;
                MessageBox.Show("Please choose size!");
            }

            return IsValid;
        }
    }
}
