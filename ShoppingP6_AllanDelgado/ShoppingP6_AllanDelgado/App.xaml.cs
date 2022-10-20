using ShoppingP6_AllanDelgado.Services;
using ShoppingP6_AllanDelgado.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_AllanDelgado
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            //con esto indicamos en cuál vista inicia el app
            MainPage = new NavigationPage(new AppLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
