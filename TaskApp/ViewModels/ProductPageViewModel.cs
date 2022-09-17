using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.DataStore.Category;
using TaskApp.DataStore.Product;
using TaskApp.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TaskApp.ViewModels
{
    public class ProductPageViewModel : ObservableObject
    {
        ProductDataStore ProductDS = new ProductDataStore();

        private CategoryModel selectedCategory;
        public CategoryModel SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        private string textFilter;
        public string TextFilter
        {
            get => textFilter;
            set 
            { SetProperty(ref textFilter, value);
                if (string.IsNullOrEmpty(value))
                {
                    Products.ReplaceRange(FetchedProducts);
                }
            }
        }


        public ObservableRangeCollection<CartModel> Products { get; set; }


        public ObservableRangeCollection<CategoryModel> Categories { get; set; }

        public ProductPageViewModel()
        {
            Products = new ObservableRangeCollection<CartModel>();
            Categories = new ObservableRangeCollection<CategoryModel>();
           
            
        }

        internal void UpdateCartCount(CartModel item)
        {
            Products.ForEach(p =>
            {
                if(p.Data.Title == item.Data.Title)
                {
                    p.Count = item.Count;
                }
            });
        }

        private void SelectedCategory_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }

        CartModel[] FetchedProducts;

        bool IsInitalized = false;

        public async Task InitilizeViewModel()
        {

            if (IsInitalized) return;

            try
            {
                var fetchedProducts = await ProductDS.GetProductAsync();
                FetchedProducts = fetchedProducts.Select(p => new CartModel { Data = p }).ToArray();
                Products.ReplaceRange(FetchedProducts);
                await GetCategories();
                IsInitalized = true;
                

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        CategoryDataStore CategoryDS = new CategoryDataStore();
        protected async Task GetCategories()
        {
            try
            {
                var categories = await CategoryDS.GetCategoryAsync();
                Categories.ReplaceRange(categories);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private Command categorySelectedCommand;
        public ICommand CategorySelectedCommand => categorySelectedCommand ??= new Command(DoCategorySelectedCommand);

        private void DoCategorySelectedCommand()
        {
            if (FetchedProducts is null) return;
            var selectedCategoryItems = FetchedProducts.Where(p => p.Data.Category.Name == SelectedCategory.Name);
            Products.ReplaceRange(selectedCategoryItems);
        }

        private Command clearFilterCommand;
        public ICommand ClearFilterCommand => clearFilterCommand ??= new Command(DoClearFilterCommand);

        private void DoClearFilterCommand()
        {
            if (FetchedProducts is null) return;
            SelectedCategory = new CategoryModel();
            Products.ReplaceRange(FetchedProducts);
        }

        private Command searchCommand;
        public ICommand SearchCommand => searchCommand ??= new Command(DoSearchCommand);

        private void DoSearchCommand()
        {
            if (string.IsNullOrEmpty(TextFilter)) return;
            var SearchedText = FetchedProducts.Where(p => p.Data.Title.ToLower().Contains(TextFilter.ToLower())); 
            Products.ReplaceRange(SearchedText);
        }

        private Command goToCartPageCommand;
        public ICommand GoToCartPageCommand => goToCartPageCommand ??= new Command(DoGoToCartPageCommand);

        private async void DoGoToCartPageCommand()
        {
            await Shell.Current.GoToAsync("CartPage");
            MessagingCenter.Send<ProductPageViewModel, CartModel[]>(this, "CartItems", FetchedProducts.Where(p=>p.Count > 0).ToArray() );
        }

    }
}
