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

        public userPage()
        {
            InitializeComponent();
            userEntry.Text = Application.Current.Properties["userName"].ToString();
        }

        async void actionButtonSave(object sender, System.EventArgs e)
        {
            Application.Current.Properties["userName"] = userEntry.Text;
            await Navigation.PopAsync();
        }
    }
}