using Wpf.Ui.Common.Interfaces;

namespace TranslatorGame.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : INavigableView<ViewModels.RegistrationViewModel>
    {
        public ViewModels.RegistrationViewModel ViewModel
        {
            get;
        }

        public RegistrationPage(ViewModels.RegistrationViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();         
        }
    }
}