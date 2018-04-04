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
        Random rnd = new Random();

        public mainPage()
        {
            InitializeComponent();
        }

        //Se genera un juego nuevo como principal
        async void actionButtonNewWait(object sender, System.EventArgs e)
        {
            Application.Current.Properties["currentGame"] = rnd.Next(100000, 999999).ToString();
            await Navigation.PushAsync(new View.userPage());
        }

        //Se entra a la pestaña para agregar un juego actual
        async void actionButtonNewGame(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.newgamePage());
        }

        //Se entra a una partida aleatoria
        async void actionButtonWait(object sender, System.EventArgs e)
        {
            Application.Current.Properties["currentGame"] = rnd.Next(100000, 999999).ToString();
            await Navigation.PushAsync(new View.userPage());
        }
    }
}