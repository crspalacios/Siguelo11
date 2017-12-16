using System;
using System.Collections.Generic;
using System.Text;

namespace Siguelo11.MainViewModels
{
    public class MainViewModel
    {
        #region Properties
        public LoginViewModel Login
        {
            get;
            set;
        }
        public AlarmaViewModel Alarma
        {
            get;
            set;
        }
        public UbicationsViewModel Ubications
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
        }
        #endregion
        #region Sigleton
        static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
