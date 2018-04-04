using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fluxx.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainPage : ContentPage
    {
        public mainPage()
        {
            InitializeComponent();
        }

        async void actionButtonNewWait(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.waitPage());
        }

        async void actionButtonNewGame(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.newgamePage());
        }

        async void actionButtonWait(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.waitPage());
        }

        async void actionButtonUser(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.userPage());
        }
    }
}