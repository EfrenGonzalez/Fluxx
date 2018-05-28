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
            string s = new Card().Codificar();
            var Cards = new Card().Decodificar(s);
            handListView.ItemsSource = Cards;
        }
    }
}