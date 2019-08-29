using CommonLib.Interfaces;
using CommonLib.Models.Tablon;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppCherrys.Services
{
    public class AzureDataStore
    {
        protected readonly IAppCherrysClient Cliente = new AppCherrysClient();
       

        public AzureDataStore()
        {
            
        }
               
    }
}
