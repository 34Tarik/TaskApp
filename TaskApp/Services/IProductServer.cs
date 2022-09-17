using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using TaskApp.Models;

namespace TaskApp.Services
{
    internal interface IProductServer
    {
        [Get("/products")]
        Task<ProductListModel> GetProductItems();
    }
}
