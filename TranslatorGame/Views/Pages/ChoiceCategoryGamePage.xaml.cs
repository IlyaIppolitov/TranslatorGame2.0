using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChoiceCategoryGamePage.xaml
    /// </summary>
    public partial class ChoiceCategoryGamePage : INavigableView<ViewModels.ChoiceGategoryGameViewModel>
    {
        public ViewModels.ChoiceGategoryGameViewModel ViewModel
        {
            get;
        }

        public ChoiceCategoryGamePage(ViewModels.ChoiceGategoryGameViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}