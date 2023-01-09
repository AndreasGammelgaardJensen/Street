using Street.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Street.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGroupPage : ContentPage
    {
        public AddGroupPage()
        {
            InitializeComponent();
            BindingContext = new AddGroupViewModel();
        }
    }
}