using Prism.Commands;
using Coffee.Models;
using System.Windows;
using System.Windows.Input;
using Coffee.DataSettings;
using Coffee.DataSettings.Implementations;
using static Coffee.DataSettings.DataSetting;
using System.Collections.ObjectModel;

namespace Coffee.ViewModels
{
    public class ExtraViewModel : BaseViewModel
    {
        #region Decorations

        private ICommand addExtraCommand;
        private bool isEnabledAddButton;
        private int count;
        private Extra extra;
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

        public int Count 
        {
            get => this.count;
            set
            {
                this.count = value;
                this.IsEnabledAddButton = IsValid();
            }
        }

        public Extra Extra 
        {
            get => this.extra;
            set
            {
                this.extra = value;
                this.IsEnabledAddButton = IsValid();
            }
        }

        public DrinkViewModel Drink 
        {
            get => this.SelectedItemViewModel.Drink; 
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
            Drink.Extras.Add(this);
        }

        private bool IsValid()
        {
            bool IsValid = true;

            if (Drink == null || Extra == null || Count <= 0 || Count > 10)
            {
                IsValid = false;
            }
            
            return IsValid;
        }
    }
}
