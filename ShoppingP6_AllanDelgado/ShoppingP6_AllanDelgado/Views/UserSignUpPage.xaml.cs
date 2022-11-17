using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingP6_AllanDelgado.ViewModels;
using ShoppingP6_AllanDelgado.Models;

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
            LoadCountriesList();
        }

        private async void LoadUserRolesList()
        {
            PckUserRole.ItemsSource = await viewModel.GetUserRoleList();
        }
        private async void LoadCountriesList()
        {
            PckCountry.ItemsSource = await viewModel.GetCountryList();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private bool UserInputValidation()
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()) &&
                TxtEmailBackUp.Text != null && !string.IsNullOrEmpty(TxtEmailBackUp.Text.Trim()) &&
                TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()) &&
                PckUserRole.SelectedIndex > -1 && PckCountry.SelectedIndex > -1)
            {
                R = true;
            }
            else
            {
                //en caso que alguna validación falle se le indica al usuario qué hace falta
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Name is required!", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Email is required!", "OK");
                    TxtEmail.Focus();
                    return false;
                }

                if (TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Password is required!", "OK");
                    TxtPassword.Focus();
                    return false;
                }

                if (TxtEmailBackUp.Text == null || string.IsNullOrEmpty(TxtEmailBackUp.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Backup Email is required!", "OK");
                    TxtEmailBackUp.Focus();
                    return false;
                }

                if (TxtPhone.Text == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Phone number is required!", "OK");
                    TxtPhone.Focus();
                    return false;
                }

                if (PckUserRole.SelectedIndex == -1)
                {
                    DisplayAlert("Validation Error", "User Role is required!", "OK");
                    //PckUserRole.Focus();
                    return false;
                }

                if (PckCountry.SelectedIndex == -1)
                {
                    DisplayAlert("Validation Error", "Country is required!", "OK");
                    return false;
                }

            }

            return R;
        }


        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //en este caso la llamada a la funcionalidad no será por Command

            if (UserInputValidation())
            {
                //Seleccionar el Id de Rol de Usuario
                UserRole UsrRol = PckUserRole.SelectedItem as UserRole;
                int IdRol = UsrRol.IduserRole;

                //Seleccionar el ID de País
                Country country = PckCountry.SelectedItem as Country;
                int IdCountry = country.Idcountry;

                //pedir confirmación de la acción a realizar 
                var answer = await DisplayAlert("Confirmation required!", "Are you sure?", "Yes", "Nop");

                if (answer)
                {
                    bool R = await viewModel.AddNewUser(TxtName.Text.Trim(),
                                                                    TxtEmail.Text.Trim(),
                                                                    TxtPassword.Text.Trim(),
                                                                    TxtEmailBackUp.Text.Trim(),
                                                                    TxtPhone.Text.Trim(),
                                                                    IdRol, IdCountry);
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





    }
}