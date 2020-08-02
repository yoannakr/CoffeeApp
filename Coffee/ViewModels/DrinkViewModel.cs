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

        public DrinkViewModel(SelectedItemViewModel selected)
        {
            this.selectedModel = selected;
        }

        public int Count { get; set; }

        public Drink Drink { get; set; }

        public DrinkSizeEnum DrinkSize { get; set; }

        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
        }

        public SelectedItemViewModel SelectedItemViewModel
        {
            get
            {
                if (selectedModel == null)
                {
                    selectedModel = new SelectedItemViewModel();
                    SelectedItemView selectedView = new SelectedItemView();

                    selectedModel.View = selectedView;

                    selectedView.DataContext = selectedModel;
                }

                return selectedModel;
            }
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
