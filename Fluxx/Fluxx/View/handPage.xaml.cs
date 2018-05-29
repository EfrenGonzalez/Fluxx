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
    public partial class handPage : ContentPage
    {
        public handPage()
        {
            InitializeComponent();
            Card card = new Card();
            var Cards = new Card().Decodificar(Application.Current.Properties["currentHand"].ToString());
            handListView.ItemsSource = Cards;
            if (Application.Current.Properties["currentGoal"].ToString().CompareTo("") == 0)
                GoalName.Text = "Aún no existe una meta";
            else GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
        }

        private void handListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            handListView.SelectedItem = null;
        }

        void UseCard(Card card)
        {
            var Cards = new Card().Decodificar(Application.Current.Properties["currentHand"].ToString());
            List<Card> newHand = new List<Card>();
            for (int i = 0; i < Cards.Count; i++) if (Cards[i].Id != card.Id) newHand.Add(Cards[i]);
            Application.Current.Properties["currentHand"] = card.CardString(newHand);
            handListView.ItemsSource = newHand;
        }

        void Win()
        {
            if (Application.Current.Properties["currentGoal"].ToString().CompareTo("") != 0)
            {
                Card goal = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString()));
                var CardsK = new Card().Decodificar(Application.Current.Properties["currentKeeper"].ToString());
                if (goal.Win(CardsK)) DisplayAlert("Ganaste", goal.Name, "OK");
            }
        }

        private void handListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var card = e.Item as Card;
            DisplayAlert("Carta Jugada", card.Name, "OK");
            if (card.Type==1)
            {
                if (Application.Current.Properties["currentKeeper"].ToString().CompareTo("") == 0)
                    Application.Current.Properties["currentKeeper"] = card.Id.ToString();
                else Application.Current.Properties["currentKeeper"] = Application.Current.Properties["currentKeeper"].ToString() + "," + card.Id.ToString();
                UseCard(card);
                Win();
            }
            else if (card.Type==2)
            {
                if (card.Rule.Item1 == 1)
                {
                    Application.Current.Properties["currentTake"] = card.Rule.Item2.ToString();
                    UseCard(card);
                }
                else if (card.Rule.Item1 == 2)
                {
                    Application.Current.Properties["currentPlay"] = card.Rule.Item2.ToString();
                    UseCard(card);
                }
            }
            else if (card.Type==3)
            {
                Application.Current.Properties["currentGoal"] = card.Id.ToString();
                GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
                UseCard(card);
                Win();
            }
        }
    }
}