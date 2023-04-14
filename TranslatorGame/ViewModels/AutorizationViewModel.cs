using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslatorGame.Infrastructure.Commands;
using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.ViewModels
{
    public partial class AutorizationViewModel : ObservableObject, INavigationAware
    {
        public void OnNavigatedTo() {}
        public void OnNavigatedFrom() {}

        private string _registration = "Регистрация";
        public string Registration
        {
            get => _registration;
            set => SetProperty(ref _registration, value);
        }
        private string _comeIn = "Войти";
        public string ComeIn
        {
            get => _comeIn;
            set => SetProperty(ref _comeIn, value);
        }
        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        private string _loginText = "Логин:";
        public string LoginText
        {
            get => _loginText;
            set => SetProperty(ref _login, value);
        }
        private string _passwordText = "Пароль:";
        public string PasswordText
        {
            get => _passwordText;
            set => SetProperty(ref _passwordText, value);
        }
        public ICommand ComeInCommand { get; }
        public ICommand RegistrationCommand { get; }
        public ICommand LoadedCommand { get; }
        public AutorizationViewModel()
        {
            ComeInCommand = new RelayCommandAsync(ComeInCommandExecute);
            RegistrationCommand = new RelayCommand(RegistrationCommandExecute, CommandExecuted);
            LoadedCommand = new RelayCommandAsync(LoadedCommandExecute);
        }

        #region Комманды
        private bool CommandExecuted() => true;
        private async Task ComeInCommandExecute()
        {
            
        }
        private void RegistrationCommandExecute()
        {

        }
        private async Task LoadedCommandExecute()
        {

        }
        #endregion
    }
}
