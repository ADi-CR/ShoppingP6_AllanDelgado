using ShoppingP6_AllanDelgado.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingP6_AllanDelgado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagmentPage : ContentPage
    {
        UserViewModel viewModel;

        public UserManagmentPage()
        {
            InitializeComponent();

            //se agrega en bindingContext de la vista contra el viewModel. 
            BindingContext = viewModel = new UserViewModel();

            LoadUserRolesList();
            LoadCountriesList();
            LoadUserData();
        }

        private void LoadUserData()
        {
            TxtName.Text = GlobalObjects.GlobalUser.Nombre;
            TxtEmail.Text = GlobalObjects.GlobalUser.CorreoElectronico;
            TxtEmailBackUp.Text = GlobalObjects.GlobalUser.CorreoRespaldo;
            TxtPhone.Text = GlobalObjects.GlobalUser.NumeroTelefono;
        }

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }
        private async void LoadCountriesList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private void BtnApply_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}