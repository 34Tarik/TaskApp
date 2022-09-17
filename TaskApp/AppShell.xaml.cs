using System;
using System.Collections.Generic;
using TaskApp.DataStore.Category;
using TaskApp.ViewModels;
using TaskApp.Views;
using TaskApp.Views.CustomViews;
using Xamarin.Forms;

namespace TaskApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));

        }
        

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            
        }
    }
}
