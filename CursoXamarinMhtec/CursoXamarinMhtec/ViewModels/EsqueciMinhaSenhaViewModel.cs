using System;
using Prism.Commands;
using Prism.Navigation;

namespace CursoXamarinMhtec.ViewModels
{
    public class EsqueciMinhaSenhaViewModel : ViewModelBase
    {
        public DelegateCommand OnFecharPopup { get; private set; }

        public EsqueciMinhaSenhaViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnFecharPopup = new DelegateCommand(FecharPopup);
        }

        private async void FecharPopup()
        {
            await NavigationService.GoBackAsync(useModalNavigation: true);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            PreencherEmailDoUsuario(parameters);
        }

        private void PreencherEmailDoUsuario(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("email", out string emailParametro))
            {
                Email = emailParametro;
            }
        }
    }
}
