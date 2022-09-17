using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using TaskApp.Models;
using TaskApp.Services;
using System.Windows.Input;
using TaskApp.ViewModels;

namespace TaskApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            //this.BindingContext = new ProductPageViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Vm = this.BindingContext as ProductPageViewModel;
            await Vm.InitilizeViewModel();
        }

        ProductPageViewModel Vm; 

        private void Button_Clicked(object sender, EventArgs e)
        {
            var increasedItem = (sender as Button).BindingContext as CartModel;
            increasedItem.Count++;
            Vm.UpdateCartCount(increasedItem);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var decreasedItem = (sender as Button).BindingContext as CartModel;
            if (decreasedItem.Count == 0) return;
            decreasedItem.Count--;
            Vm.UpdateCartCount(decreasedItem);
        }
    }
}