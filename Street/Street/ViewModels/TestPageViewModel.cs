using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Street.ViewModels
{
    public class TestPageViewModel : BaseViewModel
    {
        private string itemId;
        public TestPageViewModel()
        {
            itemId = "This is just a test ";

            SetProperty(ref itemId, "bla");

        }

        public string message { get
            {
                return "I'm the binding message";
            } set {
                message = value;
                OnPropertyChanged(nameof(message));
            
            } 

        }
    }
}