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
    public partial class rulePage : ContentPage
    {
        public rulePage()
        {
            InitializeComponent();
            string goal = Application.Current.Properties["currentGoal"].ToString();
            string take = Application.Current.Properties["currentTake"].ToString();
            string play = Application.Current.Properties["currentPlay"].ToString();
            Card card = new Card();
            var Cards = new Card().Decodificar(take + "," + play);
            ruleListView.ItemsSource = Cards;
            if (Application.Current.Properties["currentGoal"].ToString().CompareTo("") == 0)
                GoalName.Text = "Aún no existe una meta";
            else GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (take.CompareTo(Application.Current.Properties["currentTake"].ToString()) != 0)
                {
                    take = Application.Current.Properties["currentTake"].ToString();
                    Cards = new Card().Decodificar(take + "," + play);
                    ruleListView.ItemsSource = Cards;
                }
                if (play.CompareTo(Application.Current.Properties["currentPlay"].ToString()) != 0)
                {
                    play = Application.Current.Properties["currentPlay"].ToString();
                    Cards = new Card().Decodificar(take + "," + play);
                    ruleListView.ItemsSource = Cards;
                }
                if (goal.CompareTo(Application.Current.Properties["currentGoal"].ToString()) != 0)
                {
                    goal = Application.Current.Properties["currentKeeper"].ToString();
                    GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
                }
                return true;
            });
        }

        private void ruleListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ruleListView.SelectedItem = null;
        }

        private void ruleListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ruleListView.SelectedItem = null;
        }
    }
}