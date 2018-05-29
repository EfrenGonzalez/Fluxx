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
    public partial class welcomePage : ContentPage
    {
        public welcomePage()
        {
            InitializeComponent();
            Application.Current.Properties["currentGame"] = "-1";
            Application.Current.Properties["currentHand"] = "";
            Application.Current.Properties["currentKeeper"] = "";
            Application.Current.Properties["currentGoal"] = "";
            Application.Current.Properties["currentTake"] = "";
            Application.Current.Properties["currentPlay"] = "";
            Application.Current.Properties["currentPack"] = "";
            Application.Current.Properties["currentCard"] = "";

            if (!Application.Current.Properties.ContainsKey("userName"))
                Application.Current.Properties["userName"] = "Usuario";
        }

        async void actionButtonEnter(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.mainPage());
        }
    }
}