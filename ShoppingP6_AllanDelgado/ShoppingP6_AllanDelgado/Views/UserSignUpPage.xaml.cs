using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingP6_AllanDelgado.ViewModels;

namespace ShoppingP6_AllanDelgado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSignUpPage : ContentPage
    {
        UserViewModel viewModel;

        public UserSignUpPage()
        {
            InitializeComponent();

            //se agrega en bindingContext de la vista contra el viewModel. 
            BindingContext = viewModel = new UserViewModel();

            LoadUserRolesList();
        }

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }


        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //en este caso la llamada a la funcionalidad no será por Command
            //TODO: implementar Command

            bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                TxtEmail.Text.Trim(),
                                                TxtPassword.Text.Trim(),
                                                TxtEmailBackUp.Text.Trim(),
                                                TxtPhone.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Everything is OK", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong!", "OK");
            }




        }
    }
}