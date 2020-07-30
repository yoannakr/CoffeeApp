using System;
using System.Windows;
using Prism.Commands;
using Coffee.Models;
using Coffee.Enums;
using Coffee.Views;
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
        private SelectedItemViewModel selectedModel;

        public int Count { get; set; }

        public Drink Drink { get; set; }

        public DrinkSizeEnum DrinkSize { get; set; }

        //List
        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
        }

        public SelectedItemViewModel SelectedItemViewModel
        {
            get => this.selectedModel;
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedItemViewModel");
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

            decimal sizePrice = (decimal)DrinkSize / 100;
            MessageBox.Show($"{Drink.Name} {Count} {DrinkSize} {Count * (Drink.Price + sizePrice)}");

            if (SelectedItemViewModel == null)
            {
                SelectedItemViewModel selectedViewModel = new SelectedItemViewModel();
                SelectedItemView selectedView = new SelectedItemView();

                selectedViewModel.View = selectedView;

                selectedView.DataContext = selectedViewModel;

                SelectedItemViewModel = selectedViewModel;
            }

            SelectedItemViewModel.Drinks.Add(Drink);
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
