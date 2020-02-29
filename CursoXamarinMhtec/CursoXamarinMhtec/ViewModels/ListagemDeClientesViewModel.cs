using System;
using System.Collections.Generic;
using System.Linq;
using CursoXamarinMhtec.Models;
using Prism.Commands;
using Prism.Navigation;

namespace CursoXamarinMhtec.ViewModels
{
    public class ListagemDeClientesViewModel : ViewModelBase
    {
        public DelegateCommand OnIrParaTelaDeAdicionarCliente { get; private set; }

        public ListagemDeClientesViewModel(INavigationService navigationService) : base(navigationService)
        {
            CriarMockDeClientes();
            OnIrParaTelaDeAdicionarCliente = new DelegateCommand(IrParaTelaDeAdicionarCliente);
            Title = "Todos os clientes";
        }

        private async void IrParaTelaDeAdicionarCliente()
        {
            await NavigationService.NavigateAsync("CadastrarCliente");
        }

        private ClienteModel _clienteSelecionado;
        public ClienteModel ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                SetProperty(ref _clienteSelecionado, value);

                if (value is null)
                    return;

                SelecionarCliente();
            }
        }

        private async void SelecionarCliente()
        {
            var parametroCliente = new NavigationParameters
            {
                { "cliente", ClienteSelecionado }
            };

            await NavigationService.NavigateAsync("CadastrarCliente", parametroCliente);
        }

        private List<ClienteModel> _clientes;
        public List<ClienteModel> Clientes
        {
            get => _clientes;
            set => SetProperty(ref _clientes, value);
        }

        private void CriarMockDeClientes()
        {
            var clientes = new List<ClienteModel>();
            clientes.Add(CriarClienteMock(1, "MHTec Sistemas"));
            clientes.Add(CriarClienteMock(2, "Coliseu"));
            clientes.Add(CriarClienteMock(3, "Blumenau"));
            clientes.Add(CriarClienteMock(4, "Oktobeerfest"));
            Clientes = clientes;
        }

        private static ClienteModel CriarClienteMock(int id, string nome)
        {
            return new ClienteModel
            {
                Id = id,
                Nome = nome
            };
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            AtualizarListaDeClientes(parameters);
        }

        private void AtualizarListaDeClientes(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("cliente", out ClienteModel clienteCadastrado))
            {
                if (!EstaAtualizandoOCliente(parameters))
                {
                    Clientes.Add(clienteCadastrado);
                }
                else
                {
                    foreach (var cliente in Clientes)
                    {
                        if (cliente.Id.Equals(clienteCadastrado.Id))
                            cliente.Nome = clienteCadastrado.Nome;
                    }
                }

                Clientes = Clientes.ToList();
            }
        }

        private bool EstaAtualizandoOCliente(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("estaAtualizando", out bool estaAtualizando))
            {
                return estaAtualizando;
            }

            return false;
        }
    }
}
