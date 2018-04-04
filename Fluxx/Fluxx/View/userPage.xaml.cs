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
    public partial class userPage : ContentPage
    {
        string userName = "";

        public userPage()
        {
            InitializeComponent();
            userEntry.Text = Application.Current.Properties["userName"].ToString();
        }

        void TextChangedUser(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            userName = e.NewTextValue;
        }

        async void actionButtonSave(object sender, System.EventArgs e)
        {
            Application.Current.Properties["userName"] = userName;
            await Navigation.PopAsync();
        }
    }
}