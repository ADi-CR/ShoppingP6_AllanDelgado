using ShoppingP6_AllanDelgado.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShoppingP6_AllanDelgado.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}