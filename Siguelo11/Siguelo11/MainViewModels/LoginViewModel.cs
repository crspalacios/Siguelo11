namespace Siguelo11.MainViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Services;
    using System.ComponentModel;
    using System.Windows.Input;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _user;
        string _password;
        bool _isRunning;
        bool _isEnabled;
        #endregion

        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public LoginViewModel()
        {

            dialogService = new DialogService();
            navigationService = new NavigationService();

            IsRunning = false;
            IsEnabled = true;

        }
        #endregion


        #region Properties
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));

                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));

                }
            }
        }
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));

                }
            }
        }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));

                }
            }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        async void Login()
        {
            if (string.IsNullOrEmpty(User))
            {
                await dialogService.ShowMessage("Error", "Por favor escriba el usuario");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "Por favor escriba la contraseña");
                return;
            }
            if (User == "Invitado" && Password == "123456")
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Alarma = new AlarmaViewModel();
                await navigationService.Navigate("AlarmaView");
                IsRunning = true;
                IsEnabled = false;

            }
            else
            {
                await dialogService.ShowMessage("Error", "Usuario o Contraseña incorrecto...");
                User = null;
                Password = null;
                IsRunning = false;
                IsEnabled = true;
                return;

            }

        }
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        async void Register()
        {
            if (string.IsNullOrEmpty(User))
            {
                await dialogService.ShowMessage("Error", "Por favor escriba el usuario");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "Por favor escriba la contraseña");
                return;
            }
            if (User == "Invitado" && Password == "123456")
            {
                var mainViewModel = MainViewModel.GetInstance();
                // await navigationService.Navigate("AlarmasView");
            }
            IsRunning = true;
            IsEnabled = false;
            #endregion
        }
    }
}
