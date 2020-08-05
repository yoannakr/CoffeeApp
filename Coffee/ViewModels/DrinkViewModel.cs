using System;
using Prism.Commands;
using Coffee.Models;
using Coffee.Enums;
using System.Windows.Input;
using Coffee.DataSettings;
using System.Collections.ObjectModel;
using Coffee.DataSettings.Implementations;
using static Coffee.DataSettings.DataSetting;
using System.Linq;

namespace Coffee.ViewModels
{
    public class DrinkViewModel : BaseViewModel
    {
        private int count;
        private Drink drink;
        private decimal total;
        private bool hasExtras;
        private bool isEnabledAddButton;
        private DrinkSizeEnum drinkSize;
        private ObservableCollection<ExtraViewModel> extras;
        private ICommand addDrinkCommand;
        private readonly IReader xml = new XmlReader();

        public DrinkViewModel(MainWindowViewModel mainWindowViewModel,SelectedItemViewModel selected)
        {
            MainWindowViewModel = mainWindowViewModel;
            SelectedItemViewModel = selected;
        }

        public SelectedItemViewModel SelectedItemViewModel { get; }

        public MainWindowViewModel MainWindowViewModel { get; }

        public ObservableCollection<ExtraViewModel> Extras 
        {
            get
            {
                if(extras == null)
                    extras = new ObservableCollection<ExtraViewModel>();

                return extras;
            }
        }

        public int Count
        {
            get => this.count;
            set
            {
                this.count = value;
                IsEnabledAddButton = IsDrinkValid();
            }
        }

        public DrinkSizeEnum DrinkSize
        {
            get => this.drinkSize;
            set
            {
                this.drinkSize = value;
                IsEnabledAddButton = IsDrinkValid();
            }
        }

        public Drink Drink
        {
            get => this.drink;
            set
            {
                this.drink = value;
                IsEnabledAddButton = IsDrinkValid();
            }
        }

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
            get
            {
                this.total = Drink.Count * Drink.Price;
                return total;
            }
        }

        public ObservableCollection<Drink> Drinks
        {
            get => xml.ReadData<Drink>(DrinksXml);
        }

        public bool HasExtras
        {
            get => this.hasExtras;
            set
            {
                hasExtras = value;
                OnPropertyChanged("HasExtras");
            }
        }

        public ICommand AddDrinkCommand
        {
            get
            {
                if (addDrinkCommand == null)
                    addDrinkCommand = new DelegateCommand<object>(AddDrinkToSelectedItem, CanAddDrink);

                return addDrinkCommand;
            }
        }

        private bool CanAddDrink(object arg)
        {
            return true;
        }

        private void AddDrinkToSelectedItem(object obj)
        {
            SelectedItemViewModel.Drinks.Add(this);
            Drink.Count = Count;
            SelectedItemViewModel.CurrentSum += Total;
            MainWindowViewModel.BaseViewModel = new DrinkViewModel(MainWindowViewModel,SelectedItemViewModel);
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
