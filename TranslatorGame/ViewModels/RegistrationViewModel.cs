using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslatorGame.Infrastructure.Commands;
using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject, INavigationAware
    {
        public void OnNavigatedTo() {}
        public void OnNavigatedFrom() {}
        private string _newLogin;
        public string NewLogin
        {
            get => _newLogin;
            set => SetProperty(ref _newLogin, value);
        }
        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set => SetProperty(ref _newPassword, value);
        }

        private string _newPasswordCheck;
        public string NewPasswordCheck
        {
            get => _newPasswordCheck;
            set => SetProperty(ref _newPasswordCheck, value);
        }
        private string _newLoginText = "Введите логин:";
        public string NewLoginText
        {
            get => _newLoginText;
            set => SetProperty(ref _newLoginText, value);
        }
        private string _newPasswordText = "Введите пароль:";
        public string NewPasswordText
        {
            get => _newPasswordText;
            set => SetProperty(ref _newPasswordText, value);
        }
        private string _newPasswordCheckText = "Повторите пароль:";
        public string NewPasswordCheckText
        {
            get => _newPasswordCheckText;
            set => SetProperty(ref _newPasswordCheckText, value);
        }
        private string _account = "Создать аккаунт";
        public string Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }
        private string _back = "Назад";
        public string Back
        {
            get => _back;
            set => SetProperty(ref _back, value);
        }
        private string _loginIsExist;
        public string LoginIsExist
        {
            get => _loginIsExist;
            set => SetProperty(ref _loginIsExist, value);
        }
        private string _passwordsIsNotMatch;
        public string PasswordsIsNotMatch
        {
            get => _passwordsIsNotMatch;
            set => SetProperty(ref _passwordsIsNotMatch, value);
        }
        public ICommand CreateAccountCommand { get; }
        public ICommand BackCommand { get; }

        public RegistrationViewModel()
        {
            CreateAccountCommand = new RelayCommandAsync(CreateAccountCommandExecute);
            BackCommand = new RelayCommand(BackCommandExecute, CommandExecuted);
        }

        #region Комманды
        private bool CommandExecuted() => true;
        private async Task CreateAccountCommandExecute()
        {

        }
        private void BackCommandExecute()
        {

        }
        #endregion
    }
}
