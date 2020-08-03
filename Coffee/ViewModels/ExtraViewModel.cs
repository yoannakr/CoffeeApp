using Prism.Commands;
using Coffee.Models;
using System.Windows;
using System.Windows.Input;
using Coffee.DataSettings;
using System.Collections.Generic;
using Coffee.DataSettings.Implementations;
using static Coffee.DataSettings.DataSetting;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class ExtraViewModel : BaseViewModel
    {
        #region Decorations

        private ICommand addExtraCommand;
        private readonly IReader xml = new XmlReader();

        #endregion

        public ExtraViewModel(SelectedItemViewModel selectedModel)
        {
            this.SelectedItemViewModel = selectedModel;
        }

        public ObservableCollection<Extra> Extras
        {
            get => xml.ReadData<Extra>(ExtrasXml);
        }

        public int Count { get; set; }

        public Extra Extra { get; set; }

        public DrinkViewModel Drink { get; set; }

        public SelectedItemViewModel SelectedItemViewModel { get;}

        public ICommand AddExtraCommand
        {
            get
            {
                if (addExtraCommand == null)
                    addExtraCommand = new DelegateCommand<object>(AddExtraToSelectedItem);

                return addExtraCommand;
            }
        }

        private void AddExtraToSelectedItem(object obj)
        {
            if (!IsValid())
                return;

            Drink.Extras.Add(Extra);
        }

        private bool IsValid()
        {
            bool IsValid = true;

            Drink = this.SelectedItemViewModel.Drink;


            if (Drink == null)
            {
                IsValid = false;
                MessageBox.Show("Please choose drink first!");
            }else if (Extra == null)
            {
                IsValid = false;
                MessageBox.Show("Please choose extra!");
            }
            else if (Count <= 0 || Count > 10)
            {
                IsValid = false;
                MessageBox.Show("Please enter count between 1 and 10!");
            }      

            return IsValid;
        }
    }
}
