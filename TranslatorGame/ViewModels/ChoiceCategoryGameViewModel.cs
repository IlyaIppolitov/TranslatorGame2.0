using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TranslatorGame.Infrastructure.Commands;
using TranslatorGame.Infrastructure.Commands.AsyncBaseCommand;
using TranslatorGame.Models;
using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.ViewModels
{
    public partial class ChoiceGategoryGameViewModel: ObservableObject, INavigationAware, IObjectWindowMVVM
    {
        public MainWindowViewModel Parent { get; set; }
        public void OnNavigatedTo() { }
        public void OnNavigatedFrom() { }

        public DbLanguageGamesAPI dbApi;

        private string _categoryMedicine;
        public string CategoryMedicine
        {
            get => _categoryMedicine; 
            set => SetProperty(ref _categoryMedicine, value); 
        }
        private string _categoryAnimals;

        public string CategoryAnimals
        {
            get => _categoryAnimals;
            set => SetProperty(ref _categoryAnimals, value);
        }
        private string _categoryIT;

        public string CategoryIT
        {
            get => _categoryIT;
            set => SetProperty(ref _categoryIT, value);
        }
        private string _back = "Назад";
        public string Back
        {
            get => _back;
            set => SetProperty(ref _back, value);
        }

        private string _chooseCategory = "Выберите категорию:";
        public string ChooseCategory
        {
            get => _chooseCategory;
            set => SetProperty(ref _chooseCategory, value);
        }

        private string _imageSourceMedicine 
            = "https://damion.club/uploads/posts/2022-01/1641958786_49-damion-club-p-foni-v-meditsinskom-stile-49.jpg";
        public string ImageSourceMedicine
        {
            get => _imageSourceMedicine;
            set => SetProperty(ref _imageSourceMedicine, value);
        }
        private string _imageSourceAnimals
           = "https://3.404content.com/1/FB/3F/1126698588222260987/fullsize.jpg";
        public string ImageSourceAnimals
        {
            get => _imageSourceAnimals;
            set => SetProperty(ref _imageSourceAnimals, value);
        }
        private string _imageSourceIT
           = "https://i.pinimg.com/originals/a7/c0/be/a7c0beb86b6a0b947ad410e83ce46756.jpg";
        public string ImageSourceIT
        {
            get => _imageSourceIT;
            set => SetProperty(ref _imageSourceIT, value);
        }
        public ChoiceGategoryGameViewModel()//в конструктор должен прилететь язык
        {
            NewGameCommand = new RelayCommand(NewGameCommandExecute, CommandExecuted);
            BackCommand = new RelayCommand(BackCommandExecute, CommandExecuted);
            LoadedCommand = new RelayCommandAsync(LoadedCommandExecute);    
        }

        #region Комманды
        public ICommand LoadedCommand { get; }
        public ICommand NewGameCommand { get; }
        public ICommand BackCommand { get; }
        private bool CommandExecuted() => true;
        private async Task LoadedCommandExecute()
        {
            dbApi = new DbLanguageGamesAPI();
            await FillButtonsContentAsync();
        }

        private async void NewGameCommandExecute()
        {
            Parent.SelectWindowViewModel = new ChoiceGategoryGameViewModel();
            //        формируем новое окно c передачей параметров
            //        мне тут нужно запомнить язык и категорию

            //        languages.itemssource = enum.getvalues(typeof(languageoptions));

            //    languages.selectedindex = 0;

            //        var category = ((button)sender).content as string;

            //    languageoptions languageoptions;
            //        if (enum.tryparse<languageoptions>(languages.selectedvalue.tostring(), out languageoptions))
            //        {
            //            this.content = new gamewindow(category, languageoptions);
            //}
            //        else { throw new argumentexception("language not selected!");
            //}
        }
        private void BackCommandExecute()
        {
            //возвращаемся в предыдущее окно
        }
        private async Task FillButtonsContentAsync()
        {
            //подзгружаем все категории с бд
            var categories = await dbApi.GetCategoriesAsync();

            CategoryAnimals = categories.Select(c => c.Name).ToList()[1];
            CategoryMedicine = categories.Select(c => c.Name).ToList()[0];
            CategoryIT = categories.Select(c => c.Name).ToList()[2];
        }
        #endregion
    }
}
