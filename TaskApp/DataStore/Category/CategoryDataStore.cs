using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.Services;

namespace TaskApp.DataStore.Category
{
    public class CategoryDataStore
    {
        private readonly ICategoryServer categoryServer;

        public CategoryDataStore()
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
                categoryServer = RestService.For<ICategoryServer>(httpClient);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CategoryModel[]> GetCategoryAsync()
        {
            try
            {
                var CategoryList = await categoryServer.GetCategoryItems();
                return CategoryList.Data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
