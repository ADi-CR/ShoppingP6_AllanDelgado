using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingP6_AllanDelgado.Models;

namespace ShoppingP6_AllanDelgado.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        Country MyCountry { get; set; }

        public User MyUser { get; set; }

        public UserDTO MiUsuarioDTO { get; set; }

        public UserViewModel()
        {
            MyUserRole = new UserRole();
            MyUser = new User();
            MyCountry = new Country();

            MiUsuarioDTO= new UserDTO();
        }

        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                UserDTO user = new UserDTO();

                user = await MiUsuarioDTO.GetUserData(email);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<List<Country>> GetCountryList()
        {
            try
            {
                List<Country> list = new List<Country>();

                list = await MyCountry.GetCountries();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<List<UserRole>> GetUserRoleList()
        {
            try
            {
                List<UserRole> list = new List<UserRole>();

                list = await MyUserRole.GetUserRoles();

                if (list == null)
                {
                    return null;
                }
                else
                { 
                    return list;
                }

            }
            catch (Exception)
            {
                return null;                
            }

        }

        //funcion para agregar usuario
        public async Task<bool> AddNewUser(string pName,
                                            string pEmail,
                                            string pPassword,
                                            string pBkpEmail,
                                            string pPhoneNumber,
                                            int pUserRole,
                                            int pCountry)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Name = pName;
                MyUser.Email = pEmail;
                MyUser.BackUpEmail = pBkpEmail;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.UserPassword = pPassword;
                MyUser.IduserRole = pUserRole;
                MyUser.Idcountry = pCountry;

                bool R = await MyUser.AddUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { 
                IsBusy = false;
            }
            

        
        }


        //función de validación de ingreso de usuario al app
        public async Task<bool> UserAccessValidation(string pEmail, string pUserPassword)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.UserPassword = pUserPassword;

                bool R = await MyUser.ValidateLogin();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            { IsBusy = false; }
        
        }

        public async Task<bool> UpdateUser(string pName,
                                           string pEmail,
                                           string pPassword,
                                           string pBkpEmail,
                                           string pPhoneNumber,
                                           int pUserRole,
                                           int pCountry)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUsuarioDTO.Nombre = pName;
                MiUsuarioDTO.CorreoElectronico = pEmail;
                MiUsuarioDTO.CorreoRespaldo = pBkpEmail;
                MiUsuarioDTO.NumeroTelefono = pPhoneNumber;
                MiUsuarioDTO.Contrasennia = pPassword;
                MiUsuarioDTO.IDRol = pUserRole;
                MiUsuarioDTO.IDPais = pCountry;

                bool R = await MiUsuarioDTO.UpdateUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }








    }
}
