using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.Services;

namespace TaskApp.DataStore.Product
{
    public class ProductDataStore
    {
        private readonly IProductServer productServer;
        public ProductDataStore()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
            };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://api.storerestapi.com")
            };

            try
            {
                productServer = RestService.For<IProductServer>(httpClient);
            }
            catch (Exception ex)
            {

                throw;
            }



        }
        public async Task<ProductModel[]> GetProductAsync()
        {
            try
            {
                var ProductList = await productServer.GetProductItems();
                return ProductList.Data;
            }
            catch (Exception ex)
            {

                throw;
            }
        } 

        public string MyJsonConverter(object Data)
        {
            return JsonConvert.SerializeObject(Data);
        }

    }
}
