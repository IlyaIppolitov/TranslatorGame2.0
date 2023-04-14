using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {
        public void OnNavigatedTo() { }
        public void OnNavigatedFrom() { }

        private string _startGame = "Начать игру";
        public string StartGame
        {
            get => _startGame;
            set => SetProperty(ref _startGame, value);
        }
        private string _exit = "Выход";
        public string Exit
        {
            get => _exit;
            set => SetProperty(ref _exit, value);
        }
        private bool _englisgChecked = true;
        public bool EnglisgChecked
        {
            get => _englisgChecked;
            set => SetProperty(ref _englisgChecked, value);
        }
        private bool _germangChecked = false;
        public bool GermangChecked
        {
            get => _germangChecked;
            set => SetProperty(ref _germangChecked, value);
        }
        private Enum _englishLanguage = Models.LanguageOptions.English;
        public Enum EnglishLanguage
        {
            get => _englishLanguage;
            set => SetProperty(ref _englishLanguage, value);
        }
        private Enum _germanLanguage = Models.LanguageOptions.German;
        public Enum GermanLanguage
        {
            get => _germanLanguage;
            set => SetProperty(ref _germanLanguage, value);
        }
        private Enum _language = Models.LanguageOptions.English;
        public Enum Language
        {
            get => _language;
            set => SetProperty(ref _language, value);
        }
        public DashboardViewModel()
        {
            CloseApplicationCommand =
            new RelayCommand(CanCloseApplicationCommandExecute, CommandExecuted);
            StartNewGameCommand = new RelayCommand(StartNewGameCommandExecute, CommandExecuted);
            ChooseEnglishLanguageCommand =
                new RelayCommand(ChooseEnglishLanguageCommandExecute, CommandExecuted);
            //ChooseGermanLanguageCommand =
            //    new RelayCommand(ChooseGermanLanguageCommandExecute, CommandExecuted);
        }

        #region Комманды
        public ICommand CloseApplicationCommand { get; }
        public ICommand StartNewGameCommand { get; }
        public ICommand ChooseEnglishLanguageCommand { get; }
        public ICommand ChooseGermanLanguageCommand { get; }
        private bool CommandExecuted() => true;
        private void CanCloseApplicationCommandExecute() => Application.Current.Shutdown();
        private void StartNewGameCommandExecute()
        {
            //передаем Language в качестве параметра в новое окно 
        }
        private void ChooseEnglishLanguageCommandExecute()
        {
            if (EnglisgChecked)
            {
                GermangChecked = false;
                Language = Models.LanguageOptions.English;
                MessageBox.Show(Language.ToString());
            }
            else
            {
                GermangChecked = true;
                Language = Models.LanguageOptions.German;
                MessageBox.Show(Language.ToString());
            }
        }
        private void ChooseGermanLanguageCommandExecute()
        {
            if (GermangChecked)
            {
                EnglisgChecked = false;
                Language = Models.LanguageOptions.German;
                MessageBox.Show(Language.ToString());
            }
            else
            {
                EnglisgChecked = true;
                Language = Models.LanguageOptions.German;
                MessageBox.Show(Language.ToString());
            }

        }
        #endregion
    }
}
