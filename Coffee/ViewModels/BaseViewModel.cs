using Coffee.Interfaces;
using System;
using System.ComponentModel;

namespace Coffee.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private IView view;

        public IView View
        {
            get => this.view;
            set
            {
                if (value == view)

                    return;

                view = value;

                view.DataContext = this;
                OnPropertyChanged("View");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
