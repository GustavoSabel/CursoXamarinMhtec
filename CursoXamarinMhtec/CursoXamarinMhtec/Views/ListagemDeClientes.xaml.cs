using System;
using System.Collections.Generic;
using CursoXamarinMhtec.ViewModels;
using Xamarin.Forms;

namespace CursoXamarinMhtec.Views
{
    public partial class ListagemDeClientes : ContentPage
    {
        public ListagemDeClientes()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToolbarItems.Clear();
            ToolbarItems.Add(new Xamarin.Forms.ToolbarItem()
            {
                IconImageSource = "ic_add",
                Command = (this.BindingContext as ListagemDeClientesViewModel).OnIrParaTelaDeAdicionarCliente
            });

        }
    }
}
