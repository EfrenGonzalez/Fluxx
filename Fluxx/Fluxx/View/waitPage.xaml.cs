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
    public partial class waitPage : ContentPage
    {
        public waitPage()
        {
            InitializeComponent();
            labelGame.Text = Application.Current.Properties["currentGame"].ToString();
            labelPlayer1.Text = Application.Current.Properties["userName"].ToString();
            labelPlayer2.Text = "Esperando";
            labelPlayer3.Text = "Esperando";
            labelPlayer4.Text = "Esperando";
            labelPlayer5.Text = "Esperando";
            labelPlayer6.Text = "Esperando";
        }

        async void actionButtonHand(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.handPage());
        }
    }
}