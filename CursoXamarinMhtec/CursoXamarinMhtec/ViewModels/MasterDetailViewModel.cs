using System;
using System.Collections.Generic;
using CursoXamarinMhtec.Models;
using Prism.Navigation;

namespace CursoXamarinMhtec.ViewModels
{
    public class MasterDetailViewModel : ViewModelBase
    {
        public MasterDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            CriarMenus();
        }

        private MenuModel _menuSelecionado;
        public MenuModel MenuSelecionado
        {
            get => _menuSelecionado;
            set
            {
                SetProperty(ref _menuSelecionado, value);

                if (value is null)
                    return;

                NavegarParaAView();
            }
        }

        private async void NavegarParaAView()
        {
            await NavigationService.NavigateAsync($"MasterDetail/NavigationPage/{MenuSelecionado.PaginaDestino}");
        }

        private void CriarMenus()
        {
            var menus = new List<MenuModel>
            {
                CriarItemDoMenu("ic_person", "Clientes", "ListagemDeClientes"),
                CriarItemDoMenu("ic_list_alt", "Produtos", "Produtos"),
                CriarItemDoMenu("ic_shopping_cart", "Pedidos", "Pedidos")
            };

            Menus = menus;
        }

        private static MenuModel CriarItemDoMenu(string imagem, string texto, string paginaDestino)
        {
            return new MenuModel
            {
                Imagem = imagem,
                Texto = texto,
                PaginaDestino = paginaDestino
            };
        }

        private List<MenuModel> _menus;
        public List<MenuModel> Menus
        {
            get => _menus;
            set => SetProperty(ref _menus, value);
        }
    }
}
