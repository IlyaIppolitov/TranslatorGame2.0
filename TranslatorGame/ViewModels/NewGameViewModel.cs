using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TranslatorGame.Infrastructure.Commands;
using TranslatorGame.Models;
using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.ViewModels
{
    public partial class NewGameViewModel : ObservableObject, INavigationAware
    {
        public void OnNavigatedTo() { }
        public void OnNavigatedFrom() { }

        public DbLanguageGamesAPI dbApi = new DbLanguageGamesAPI();

        public OpenAiLib AiLib = new OpenAiLib();

        IEnumerator<Word> _enumerator;

        private WordProvider _provider;

        private List<Word> _dictionaryWords;

        private List<Word> _playerWords;

        private string _categoryName;
        public string _playerLogin = "Champion";
        private int _rightNumber;
        LanguageOptions _languageOptions;
        public Word QWord { get; set; }

        private string _guessWord;
        public string QuessWord
        {
            get => _guessWord;
            set => SetProperty(ref _guessWord, value);
        }
        private string _answer1;
        public string Answer1
        {
            get => _answer1;
            set => SetProperty(ref _answer1, value);
        }
        private string _answer2;
        public string Answer2
        {
            get => _answer2;
            set => SetProperty(ref _answer2, value);
        }
        private string _answer3;
        public string Answer3
        {
            get => _answer3;
            set => SetProperty(ref _answer3, value);
        }
        private string _answer4;
        public string Answer4
        {
            get => _answer4;
            set => SetProperty(ref _answer4, value);
        }
        private string _back = "Назад";
        public string Back
        {
            get => _back;
            set => SetProperty(ref _back, value);
        }
        private BitmapImage _outputImage;
        public BitmapImage OutputImage
        {
            get => _outputImage;
            set => SetProperty(ref _outputImage, value);
        }
        private string _gameIsDone;
        public string GameIsDone
        {
            get => _gameIsDone;
            set => SetProperty(ref _gameIsDone, value);
        }
        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
        private string _color;
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
        public NewGameViewModel()
        {
            BackCommand = new RelayCommand(BackCommandExecute, CommandExecuted);
            LoadedCommand = new RelayCommandAsync(LoadedCommandExecute);
            CheckAnswer1Command = new RelayCommandAsync(CheckAnswer1CommandExecute);
            CheckAnswer2Command = new RelayCommandAsync(CheckAnswer2CommandExecute);
            CheckAnswer3Command = new RelayCommandAsync(CheckAnswer3CommandExecute);
            CheckAnswer4Command = new RelayCommandAsync(CheckAnswer4CommandExecute);
        }

        #region Комманды
        public ICommand CheckAnswer1Command { get;  }        
        public ICommand CheckAnswer2Command { get; }
        public ICommand CheckAnswer3Command { get; }
        public ICommand CheckAnswer4Command { get; }
        public ICommand BackCommand { get; }
        public ICommand LoadedCommand { get; }
        private bool CommandExecuted() => true;
        private async Task LoadedCommandExecute()
        {
            //определить имеющийся перечень слов из базы данных
            //!!!!!!
            _categoryName = "Животные";
            //!!!!!!

            _dictionaryWords = await dbApi.GetWordByCategoryAsync(_categoryName);
            _playerWords = await dbApi.GetPlayerWords(_playerLogin, _categoryName);

            _provider = new WordProvider(new[]
            {
                (_dictionaryWords, 1.0),
                (_playerWords, 0.6)
            });
            _enumerator = _provider.Take(_dictionaryWords.Count + _playerWords.Count).GetEnumerator();
            //await dbApi.AddNewPlayer(_playerLogin, " ");
            await FillAllButtons();
        }
        private void BackCommandExecute()
        {
            //оформляем новое окно
        }

        #endregion

        private async Task CheckAnswer1CommandExecute()
        {
            Content = Answer1;
            await CheckRightButton(Content);
        }
        private async Task CheckAnswer2CommandExecute()
        {
            Content = Answer2;
            await CheckRightButton(Content);
        }
        private async Task CheckAnswer3CommandExecute()
        {
            Content = Answer3;
            await CheckRightButton(Content);
        }
        private async Task CheckAnswer4CommandExecute()
        {
            Content = Answer4;
            await CheckRightButton(Content);
        }
        private async Task FillAllButtons()
        {
            _enumerator.MoveNext();

            QWord = _enumerator.Current;

            if (QWord == null)
            { 
                GameIsDone = "Молодец! Ты прошёл все слова в этой категории!";
                //Content = new ChoiceGameWindow(); вызвать новое окно, обновить его
                return;
            }

            QuessWord = QWord.Russian;
            Random rnd = new Random();
      
            _rightNumber = rnd.Next(4) + 1;
            PutContentToButton(_rightNumber, QWord);

            //OutputImage = await AiLib.GetPictureAsync(QWord.English);
            var options = GetOptionsWords(QWord, _dictionaryWords);

            int j = 0;
            for (int i = 1; i <= 4; ++i)
            {
                if (i == _rightNumber)
                {
                    continue;
                }
                PutContentToButton(i, options[j]);
                j++;
            }
        }

        void PutContentToButton(int buttonNumber, Word word)
        {
            string wordString;
            switch (_languageOptions)
            {
                case LanguageOptions.English:
                    wordString = word.English;
                    break;

                case LanguageOptions.German:
                    wordString = word.German;
                    break;

                default:
                    throw new Exception("Что-то пошло не так в части выбора языка!");
            }
            switch (buttonNumber)
            {
                //нужно погрузить в каждую кнопку контент
                case 1:
                    Answer1 = wordString;
                    break;
                case 2:
                    Answer2 = wordString;
                    break;
                case 3:
                    Answer3 = wordString;
                    break;
                case 4:
                    Answer4 = wordString;
                    break;
            }
        }

        List<Word> GetOptionsWords(Word qWord, List<Word> words)
        {
            List<Word> options = new List<Word>();
            var countOfWords = words.Count;
            Random rnd = new Random();

            while (options.Count != 3)
            {
                var word = words[rnd.Next(countOfWords)];
                if (word.Id == qWord.Id) continue;
                var flag = false;
                foreach (var w in options)
                {
                    if (w.Id == word.Id) flag = true;
                }
                if (flag) continue;

                options.Add(word);
            }
            return options;
        }

        private async Task CheckRightButton(string content)
        {
            //язык

            if (content == QWord.English)
            {
                //!!!!!!!!!!
                //MessageBox.Show("Молодец!");
                //!!!!!!!!!!
                await FillAllButtons();
            }
            else
            {
                //!!!!!!!!!!!!
                //MessageBox.Show("Промазал! Мы всё запишем и вернёмся!");
                //!!!!!!!!!!
                //await dbApi.AddWordToPlayerAsync(_playerLogin, QWord);
                await FillAllButtons();
                //Content = new GameWindow(_categoryName, _languageOptions);
            }
        }
    }
}
