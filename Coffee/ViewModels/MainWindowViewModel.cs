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

        public BaseViewModel BaseViewModel
        {
            get => this.viewModel;
            set
            {
                viewModel = value;
                OnPropertyChanged("BaseViewModel");
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
            DrinkViewModel drinkViewModel = new DrinkViewModel();
            DrinkView drinkView = new DrinkView();

            drinkViewModel.View = drinkView;

            drinkView.DataContext = drinkViewModel;

            BaseViewModel = drinkViewModel;
        }
    }
}
