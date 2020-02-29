using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CursoXamarinMhtec.Models;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace CursoXamarinMhtec.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public DelegateCommand OnLogar { get; private set; }
        public DelegateCommand OnEsqueciMinhaSenha { get; private set; }
        
        public LoginViewModel(INavigationService navigationService, IUserDialogs userDialogs) : base(navigationService)
        {
            _userDialogs = userDialogs;
            UsuarioModel = new UsuarioModel();
            OnLogar = new DelegateCommand(Logar);
            OnEsqueciMinhaSenha = new DelegateCommand(EsqueciMinhaSenha);
        }

        private async void EsqueciMinhaSenha()
        {
            var parametrosDaNavegacao = new NavigationParameters
            {
                { "email", UsuarioModel?.Email }
            };

            await NavigationService.NavigateAsync("EsqueciMinhaSenha", parametrosDaNavegacao, true);
        }

        private async void Logar()
        {
            if (await ValidarLogin())
                await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        private async Task<bool> ValidarLogin()
        {
            if (UsuarioNaoEhValido())
            {
                await _userDialogs.AlertAsync("Digite um usuário válido", okText: "Ok");
                return false;
            }

            if (SenhaNaoEhValido())
            {
                await _userDialogs.AlertAsync("Digite uma senha válida", okText: "Ok");
                return false;
            }

            return true;
        }

        private bool UsuarioNaoEhValido()
        {
            return string.IsNullOrEmpty(UsuarioModel.Email);
        }

        private bool SenhaNaoEhValido()
        {
            return string.IsNullOrEmpty(UsuarioModel.Senha);
        }

        private UsuarioModel _usuarioModel;
        private readonly IUserDialogs _userDialogs;

        public UsuarioModel UsuarioModel
        {
            get => _usuarioModel;
            set => SetProperty(ref _usuarioModel, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
