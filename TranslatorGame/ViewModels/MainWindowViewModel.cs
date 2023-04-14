using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using TranslatorGame.Models;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace TranslatorGame.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IObjectWindowMVVM
    {
        public MainWindowViewModel Parent { get; set; }
        private IObjectWindowMVVM _selectWindowViewModel;
        public IObjectWindowMVVM SelectWindowViewModel
        {
            get => _selectWindowViewModel;
            set
            {
                _selectWindowViewModel = value;
                _selectWindowViewModel.Parent = this;
                SetProperty(ref _selectWindowViewModel, value);
            }
        }

        private string _Tittle;

        public string Tittle
        {
            get { return _Tittle; }
            set { SetProperty(ref _Tittle, value); }
        }


        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            this.SelectWindowViewModel = new ChoiceGategoryGameViewModel() { Parent = this };

            ApplicationTitle = "WPF UI - TranslatorGame";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },
                 new NavigationItem()
                {
                    Icon = SymbolRegular.Accessibility24,
                    PageType = typeof(Views.Pages.ChoiceCategoryGamePage)
                },
                 new NavigationItem()
                {
                    Icon = SymbolRegular.Accessibility48,
                    PageType = typeof(Views.Pages.NewGamePage)
                },
                new NavigationItem()
                {
                    Icon = SymbolRegular.Accessibility48,
                    PageType = typeof(Views.Pages.AutorizationPage)
                },
                new NavigationItem()
                {
                    Icon = SymbolRegular.Accessibility48,
                    PageType = typeof(Views.Pages.RegistrationPage)
                }

            };
            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
