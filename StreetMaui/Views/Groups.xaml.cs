using Street.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetMaui.Views
{
    public partial class Groups : ContentPage
    {
        public Groups()
        {
            InitializeComponent();
            BindingContext = new GroupsViewModel();
        }
    }
}