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
    public partial class keeperEPage : ContentPage
    {
        public keeperEPage()
        {
            InitializeComponent();
            string keepers = Application.Current.Properties["currentKeeperE"].ToString();
            string goal = Application.Current.Properties["currentGoal"].ToString();
            Card card = new Card();
            var Cards = new Card().Decodificar(keepers);
            keeperListView.ItemsSource = Cards;
            if (Application.Current.Properties["currentGoal"].ToString().CompareTo("") == 0)
                GoalName.Text = "Aún no existe una meta";
            else GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (keepers.CompareTo(Application.Current.Properties["currentKeeperE"].ToString()) != 0)
                {
                    keepers = Application.Current.Properties["currentKeeperE"].ToString();
                    Cards = new Card().Decodificar(keepers);
                    keeperListView.ItemsSource = Cards;
                }
                if (goal.CompareTo(Application.Current.Properties["currentGoal"].ToString()) != 0)
                {
                    goal = Application.Current.Properties["currentKeeperE"].ToString();
                    GoalName.Text = new Card(Convert.ToInt32(Application.Current.Properties["currentGoal"].ToString())).Name;
                }
                return true;
            });
        }

        private void keeperListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            keeperListView.SelectedItem = null;
        }

        private void keeperListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            keeperListView.SelectedItem = null;
        }
    }
}