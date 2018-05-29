using Fluxx.Model;
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
            Application.Current.Properties["currentPlayer"] = "1";
            labelPlayer2.Text = "Esperando";
            labelPlayer3.Text = "Esperando";
            labelPlayer4.Text = "Esperando";
            labelPlayer5.Text = "Esperando";
            labelPlayer6.Text = "Esperando";
        }

        async void actionButtonHand(object sender, System.EventArgs e)
        {
            var card = new Card();
            string pack = card.Codificar();
            var hand = card.Decodificar(pack);
            string shand = "";
            int first = Convert.ToInt32(Application.Current.Properties["currentPlayer"]) - 1;
            int last = first + 1;
            for (int i = first * 5; i < 5 * last - 1; i++) shand += card.GetId(i, pack) + ",";
            shand += card.GetId(5 * last - 1, pack);

            Application.Current.Properties["currentKeeper"] = "";
            Application.Current.Properties["currentGoal"] = "";
            Application.Current.Properties["currentCard"] = "6";
            Application.Current.Properties["currentTake"] = "1";
            Application.Current.Properties["currentPlay"] = "1";
            Application.Current.Properties["currentPack"] = pack;
            Application.Current.Properties["currentHand"] = shand;

            await Navigation.PushAsync(new View.gamePage());
        }
    }
}