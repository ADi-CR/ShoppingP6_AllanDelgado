using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingP6_AllanDelgado.Models;

namespace ShoppingP6_AllanDelgado.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        Country MyCountry { get; set; }

        public CountryViewModel()
        {
            MyCountry= new Country();

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

    }
}
