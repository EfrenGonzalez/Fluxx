﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fluxx.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class newgamePage : ContentPage
    {
        public newgamePage()
        {
            InitializeComponent();
        }

        async void actionButtonWait(object sender, System.EventArgs e)
        {
            Application.Current.Properties["currentGame"] = gameEntry.Text;
            await Navigation.PushAsync(new View.userPage());
        }
    }
}