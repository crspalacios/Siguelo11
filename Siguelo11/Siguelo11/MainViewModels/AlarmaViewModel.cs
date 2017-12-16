namespace Siguelo11.MainViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using System;
    using Services;
    public class AlarmaViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _dato;
        #endregion

        #region Properties
        public string Dato
        {
            get
            {
                return _dato;
            }
            set
            {
                if (_dato != value)
                {
                    _dato = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dato)));

                }
            }
        }
        #endregion

        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public AlarmaViewModel()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
            Dato = "hola";
        }
        #endregion

        #region Commands
        public ICommand MapsCommand
        {
            get
            {
                return new RelayCommand(Maps);
            }
        }

        async void Maps()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Ubications = new UbicationsViewModel();
            await navigationService.Navigate("UbicationsView");
        }
        #endregion

    }
}

