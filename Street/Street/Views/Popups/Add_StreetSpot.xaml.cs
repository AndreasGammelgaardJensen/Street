using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Street.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_StreetSpot : Popup
    {
        public Add_StreetSpot()
        {
            InitializeComponent();
        }
    }
}