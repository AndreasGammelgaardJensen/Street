using Street.ViewModels;

namespace StreetMaui.Views
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