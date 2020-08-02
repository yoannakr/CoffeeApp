using System;
using System.Windows.Input;
using Coffee.Views;
using Prism.Commands;

namespace Coffee.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel viewModel;
        private ICommand drinksCommand;
        private ICommand extrasCommand;
        private DrinkViewModel drinkViewModel;
        private ExtraViewModel extraViewModel;
        private SelectedItemViewModel selectedModel;

        public BaseViewModel BaseViewModel
        {
            get => this.viewModel;
            set
            {
                viewModel = value;
                OnPropertyChanged("BaseViewModel");
            }
        }

        public DrinkViewModel DrinkViewModel
        {
            get
            {
                if (drinkViewModel == null)
                {
                    drinkViewModel = new DrinkViewModel(SelectedItemViewModel);
                    DrinkView drinkView = new DrinkView();

                    drinkViewModel.View = drinkView;

                    drinkView.DataContext = drinkViewModel;
                }

                return drinkViewModel;
            }
            set
            {
                drinkViewModel = value;
                OnPropertyChanged("DrinkViewModel");
            }
        }

        public ExtraViewModel ExtraViewModel
        {
            get
            {
                if (extraViewModel == null)
                {
                    extraViewModel = new ExtraViewModel();
                    ExtraView extraView = new ExtraView();

                    extraViewModel.View = extraView;

                    extraView.DataContext = extraViewModel;
                }

                return extraViewModel;
            }
            set
            {
                extraViewModel = value;
                OnPropertyChanged("ExtraViewModel");
            }
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

        public ICommand DrinksCommand
        {
            get
            {
                if (drinksCommand == null)
                    drinksCommand = new DelegateCommand<object>(SelectDrinkViewModel);

                return drinksCommand;
            }
        }

        private void SelectDrinkViewModel(object obj)
        {
            BaseViewModel = DrinkViewModel;
        }

        public ICommand ExtrasCommand
        {
            get
            {
                if (extrasCommand == null)
                    extrasCommand = new DelegateCommand<object>(SelectExtraViewModel);

                return extrasCommand;
            }
        }

        private void SelectExtraViewModel(object obj)
        {
            BaseViewModel = ExtraViewModel;
        }

    }
}
