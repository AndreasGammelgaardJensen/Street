﻿using Street.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Street.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Groups : ContentPage
    {
        public Groups()
        {
            InitializeComponent();
            BindingContext = new GroupsViewModel();
        }
    }
}