using CommunityToolkit.Maui.Views;
using Street.Events;
using Street.ViewModels;


namespace StreetMaui.Views.Popups
{
    public partial class ShowGroupsPopup : Popup
    {

        public ShowGroupsPopup(ItemEvents itemEvents)
        {
            InitializeComponent();
            BindingContext = new ShowGroupsViewModel(itemEvents, this);
        }
    }
}