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
        private bool isEnabledAddButton;
        private int count;
        private Drink drink;
        private DrinkSizeEnum drinkSize;
        private ObservableCollection<ExtraViewModel> extras;
        private readonly IReader xml = new XmlReader();

        public DrinkViewModel(SelectedItemViewModel selected)
        {
            this.SelectedItemViewModel = selected;
        }

        public int Count 
        {
            get => this.count;
            set
            {
                this.count = value;
                this.IsEnabledAddButton = IsDrinkValid();
            }
        }

        public Drink Drink 
        {
            get => this.drink;
            set
            {
                this.drink = value;
                this.IsEnabledAddButton = IsDrinkValid();
            }
        }

        public DrinkSizeEnum DrinkSize 
        {
            get => this.drinkSize;
            set
            {
                this.drinkSize = value;
                this.IsEnabledAddButton = IsDrinkValid();
            }
        }

        public SelectedItemViewModel SelectedItemViewModel { get; }

        public bool IsEnabledAddButton
        {
            get => this.isEnabledAddButton;
            set
            {
                this.isEnabledAddButton = value;
                OnPropertyChanged("IsEnabledAddButton");
            }
        }

        public decimal Total
        {
            get => this.Count * this.Drink.Price;
        }

        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
        }

        public ObservableCollection<ExtraViewModel> Extras { get; }

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
            SelectedItemViewModel.Drinks.Add(this);
            SelectedItemViewModel.HasItems = true;
        }

        private bool IsDrinkValid()
        {
            bool IsValid = true;

            if (Drink == null || Count <= 0 || Count > 10 || !Enum.IsDefined(typeof(DrinkSizeEnum), DrinkSize))
            {
                IsValid = false;    
            }
           
            return IsValid;
        }
    }
}
