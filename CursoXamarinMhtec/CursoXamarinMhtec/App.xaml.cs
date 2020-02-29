using Prism;
using Prism.Ioc;
using CursoXamarinMhtec.ViewModels;
using CursoXamarinMhtec.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;
using System;
using Acr.UserDialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CursoXamarinMhtec
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("/MasterDetail/NavigationPage/ListagemDeClientes");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegistrarInstanciasDeNavegacao(containerRegistry);
            RegistrarInstanciasDosServicos(containerRegistry);
        }

        private void RegistrarInstanciasDosServicos(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(UserDialogs.Instance);
        }

        private static void RegistrarInstanciasDeNavegacao(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<EsqueciMinhaSenha, EsqueciMinhaSenhaViewModel>();
            containerRegistry.RegisterForNavigation<MasterDetail>();
            containerRegistry.RegisterForNavigation<ListagemDeClientes, ListagemDeClientesViewModel>();
            containerRegistry.RegisterForNavigation<CadastrarCliente, CadastrarClienteViewModel>();
        }
    }
}
