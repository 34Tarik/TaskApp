using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskApp.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutList : ContentView
    {
        public FlyoutList()
        {
            InitializeComponent();
        }





        #region ItemsSource
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList<CategoryModel>), typeof(FlyoutList), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as FlyoutList;
            if (newV != null && !(newV is IList<CategoryModel>)) return;
            var oldItemsSource = (IList<CategoryModel>)old;
            var newItemsSource = (IList<CategoryModel>)newV;
            me?.ItemsSourceChanged(oldItemsSource, newItemsSource);
        });

        private void ItemsSourceChanged(IList<CategoryModel> oldItemsSource, IList<CategoryModel> newItemsSource)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public IList<CategoryModel> ItemsSource
        {
            get => (IList<CategoryModel>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        #endregion





        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}