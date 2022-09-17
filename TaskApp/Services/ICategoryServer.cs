using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Services
{
    internal interface ICategoryServer
    {
        [Get("/categories")]
        Task<CategoryListModel> GetCategoryItems(); 
    }
}
