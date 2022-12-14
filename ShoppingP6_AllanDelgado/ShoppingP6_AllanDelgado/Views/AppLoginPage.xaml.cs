using Acr.UserDialogs;
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
    public partial class AppLoginPage : ContentPage
    {
        UserViewModel vm;

        public AppLoginPage()
        {
            InitializeComponent();

            this.BindingContext = vm = new UserViewModel();

        }

        private void CmdWatchPassword(object sender, ToggledEventArgs e)
        {
            if (SwWatchPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnUserSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSignUpPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool R = false;

            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) && 
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Checking User Data...");
                    await Task.Delay(2000);

                    string u = TxtUserName.Text.Trim();
                    string p = TxtPassword.Text.Trim();

                    R = await vm.UserAccessValidation(u, p);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await DisplayAlert("Validation Error", "Username and password are required", "OK");
                return;
            }

            if (R)
            {
                try
                {
                    GlobalObjects.GlobalUser = await vm.GetUserData(TxtUserName.Text.Trim());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                    return;                    
                }

                await Navigation.PushAsync(new ActionMenuPage());
            }
            else
            {
                await DisplayAlert(":(", "Incorrect Username or Password!", "OK");
            }

        }
    }
}