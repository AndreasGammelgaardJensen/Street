using Street.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Street.Views
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