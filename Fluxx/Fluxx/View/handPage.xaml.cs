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
        int iplay = 0;
        int mplay = 1;
        int mtake = 1;

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

        void UseCard(Card card, int k)
        {
            List<Card> Cards = new List<Card>();
            if (k==0) Cards = new Card().Decodificar(Application.Current.Properties["currentHand"].ToString());
            else Cards = new Card().Decodificar(Application.Current.Properties["currentEnemy"].ToString());
            List<Card> newHand = new List<Card>();
            for (int i = 0; i < Cards.Count; i++) if (Cards[i].Id != card.Id) newHand.Add(Cards[i]);
            if (k == 0)
            {
                Application.Current.Properties["currentHand"] = card.CardString(newHand);
                handListView.ItemsSource = newHand;
            }
            else Application.Current.Properties["currentEnemy"] = card.CardString(newHand);
        }

        void Win()
        {
            if (Application.Current.Properties["currentGoal"].ToString().CompareTo("") != 0)
            {
                Card goal = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString()));
                var CardsK = new Card().Decodificar(Application.Current.Properties["currentKeeper"].ToString());
                if (goal.Win(CardsK)) DisplayAlert("Ganaste", "Jugador 1", "OK");
                CardsK = new Card().Decodificar(Application.Current.Properties["currentEnemy"].ToString());
                if (goal.Win(CardsK)) DisplayAlert("Ganaste", "Jugador 2", "OK");
            }
        }

        private void PlayCard(Card card, int i)
        {
            if (card.Type == 1)
            {
                if (Application.Current.Properties["currentKeeper"].ToString().CompareTo("") == 0)
                    Application.Current.Properties["currentKeeper"] = card.Id.ToString();
                else Application.Current.Properties["currentKeeper"] = Application.Current.Properties["currentKeeper"].ToString() + "," + card.Id.ToString();
                UseCard(card, i);
                Win();
            }
            else if (card.Type == 2)
            {
                if (card.Rule.Item1 == 1)
                {
                    mtake = card.Rule.Item2;
                    Application.Current.Properties["currentTake"] = card.Id.ToString();
                    UseCard(card, i);
                }
                else if (card.Rule.Item1 == 2)
                {
                    mplay = card.Rule.Item2;
                    Application.Current.Properties["currentPlay"] = card.Id.ToString();
                    UseCard(card, i);
                }
            }
            else if (card.Type == 3)
            {
                Application.Current.Properties["currentGoal"] = card.Id.ToString();
                GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
                UseCard(card, i);
                Win();
            }
            if (i == 0)
            {
                iplay++;
                if (iplay >= mplay || Application.Current.Properties["currentHand"].ToString().CompareTo("") == 0)
                {
                    iplay = 0;
                    EnemyTurn();
                    for (int j = 0; j < mplay && Application.Current.Properties["currentEnemy"].ToString().CompareTo("") != 0; j++) PlayEnemyCard(FirstCard(), 1);
                    NewTurn();
                }
            }
        }

        private Card FirstCard()
        {
            if (Application.Current.Properties["currentEnemy"].ToString().CompareTo("") != 0)
            {
                string[] hand = Application.Current.Properties["currentEnemy"].ToString().Split(',');
                return new Card(Convert.ToInt32(hand[0]));
            }
            return new Card();
        }

        private void PlayEnemyCard(Card card, int i)
        {
            if (card.Type == 1)
            {
                if (i == 0)
                {
                    if (Application.Current.Properties["currentKeeper"].ToString().CompareTo("") == 0)
                        Application.Current.Properties["currentKeeper"] = card.Id.ToString();
                    else Application.Current.Properties["currentKeeper"] = Application.Current.Properties["currentKeeper"].ToString() + "," + card.Id.ToString();
                }
                else
                {
                    if (Application.Current.Properties["currentKeeperE"].ToString().CompareTo("") == 0)
                        Application.Current.Properties["currentKeeperE"] = card.Id.ToString();
                    else Application.Current.Properties["currentKeeperE"] = Application.Current.Properties["currentKeeper"].ToString() + "," + card.Id.ToString();
                }
                UseCard(card, i);
                Win();
            }
            else if (card.Type == 2)
            {
                if (card.Rule.Item1 == 1)
                {
                    mtake = card.Rule.Item2;
                    Application.Current.Properties["currentTake"] = card.Id.ToString();
                    UseCard(card, i);
                }
                else if (card.Rule.Item1 == 2)
                {
                    mplay = card.Rule.Item2;
                    Application.Current.Properties["currentPlay"] = card.Id.ToString();
                    UseCard(card, i);
                }
            }
            else if (card.Type == 3)
            {
                Application.Current.Properties["currentGoal"] = card.Id.ToString();
                GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
                UseCard(card, i);
                Win();
            }
        }

        private void handListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var card = e.Item as Card;
            DisplayAlert("Carta Jugada", card.Name, "OK");
            PlayCard(card, 0);
        }

        private void NewTurn()
        {
            int j = Convert.ToInt32(Application.Current.Properties["currentCard"].ToString());
            string pack = Application.Current.Properties["currentPack"].ToString();
            string hand = Application.Current.Properties["currentHand"].ToString();
            string[] id = pack.Split(',');
            for (int i=j;i<j+mtake;i++)
            {
                if (hand.CompareTo("") != 0) hand += "," + id[i];
                else hand = id[i];
            }
            Application.Current.Properties["currentHand"] = hand;
            Application.Current.Properties["currentCard"] = (j + mtake).ToString();
            Card card = new Card();
            var Cards = new Card().Decodificar(Application.Current.Properties["currentHand"].ToString());
            handListView.ItemsSource = Cards;
            DisplayAlert("Nuevo Turno", "Jugador 2", "OK");
        }

        private void EnemyTurn()
        {
            int j = Convert.ToInt32(Application.Current.Properties["currentCard"].ToString());
            string pack = Application.Current.Properties["currentPack"].ToString();
            string hand = Application.Current.Properties["currentEnemy"].ToString();
            string[] id = pack.Split(',');
            for (int i = j; i < j + mtake; i++)
            {
                if (hand.CompareTo("") != 0) hand += "," + id[i];
                else hand = id[i];
            }
            Application.Current.Properties["currentEnemy"] = hand;
            Application.Current.Properties["currentCard"] = (j + mtake).ToString();
            DisplayAlert("Nuevo Turno", "Jugador 1", "OK");
        }
    }
}