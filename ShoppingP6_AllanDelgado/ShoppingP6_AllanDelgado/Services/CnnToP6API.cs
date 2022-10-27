using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingP6_AllanDelgado.Services
{
    public static class CnnToP6API
    {
        //en esta clase se definen las rutas de consumo del API 
        //además se define la info de API Key necesaria 
        //para poder consumir los controladores. 

        public static string ProductionURL = "http://192.168.0.169:45455/api/";
        public static string TestingURL = "http://192.168.0.169:45455/api/";

        public static string ApiKeyName = "P6ApiKey";
        public static string ApiKeyValue = "P6shoppingQwerty1234/*";

    }
}
