using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob_Xamarin.ViewModels;

using Xamarin.Forms;
using EntMob_Xamarin.Models;

namespace EntMob_Xamarin
{
    public partial class ValuesPage : ContentPage
    {
        public ValuesPage()
        {
            InitializeComponent();

            var people = new List<User> {
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},
                new User () { Username = "Jonas" , Password = "Allard"},

            };

            listView.ItemsSource = people;
            BindingContext = new ValuesViewModel();
        }
    }
}
