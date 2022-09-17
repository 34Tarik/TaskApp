using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TaskApp.ViewModels
{
    public class CartPageViewModel : ObservableObject
    {
        public ObservableRangeCollection<CartModel> Products { get; set; }

        public CartPageViewModel()
        {
            Products = new ObservableRangeCollection<CartModel>();
            MessagingCenter.Subscribe<ProductPageViewModel, CartModel[]>(this, "CartItems", (sender, arg) =>
            {
                Products.ReplaceRange(arg);
                
                MessagingCenter.Unsubscribe<ProductPageViewModel, CartModel[]>(this, "CartItems");
            });

            

        }

        



    }
}
