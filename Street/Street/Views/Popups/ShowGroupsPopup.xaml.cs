using Street.Events;
using Street.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Street.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowGroupsPopup : Popup
    {

        public ShowGroupsPopup(ItemEvents itemEvents)
        {
            InitializeComponent();
            BindingContext = new ShowGroupsViewModel(itemEvents, this);
        }
    }
}