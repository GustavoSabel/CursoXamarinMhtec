using System;
using CursoXamarinMhtec.Models;
using Prism.Commands;
using Prism.Navigation;

namespace CursoXamarinMhtec.ViewModels
{
    public class CadastrarClienteViewModel : ViewModelBase
    {
        public DelegateCommand OnCadastrarCliente { get; private set; }
        public bool EstaAtualizando { get; set; }

        public CadastrarClienteViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Cadastrar Cliente";
            Cliente = new ClienteModel();
            OnCadastrarCliente = new DelegateCommand(CadastrarCliente);
        }

        private async void CadastrarCliente()
        {
            var parametroCliente = new NavigationParameters
            {
                { "cliente", Cliente },
                { "estaAtualizando", EstaAtualizando }
            };

            if (Cliente.Id == 0)
                Cliente.Id = new Random(1000).Next();

            await NavigationService.GoBackAsync(parametroCliente);
        }

        private ClienteModel _cliente;
        public ClienteModel Cliente
        {
            get => _cliente;
            set
            {
                SetProperty(ref _cliente, value);
            }
        }

        private string _textoAcao = "Cadastrar cliente";
        public string TextoAcao
        {
            get => _textoAcao;
            set
            {
                SetProperty(ref _textoAcao, value);
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            AtualizarCliente(parameters);
        }

        private void AtualizarCliente(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("cliente", out ClienteModel clienteSelecionado))
            {
                Cliente = clienteSelecionado;
                AtribuirTextosDeEditandoCliente();
            }
        }

        private void AtribuirTextosDeEditandoCliente()
        {
            Title = "Atualizar Cliente";
            TextoAcao = "Atualizar";
            EstaAtualizando = true;
        }
    }
}
