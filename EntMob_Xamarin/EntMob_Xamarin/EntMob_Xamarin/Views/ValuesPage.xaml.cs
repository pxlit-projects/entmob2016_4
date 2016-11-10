using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntMob_Xamarin.ViewModels;
using Xamarin.Forms;

namespace EntMob_Xamarin
{
    public partial class ValuesPage : ContentPage
    {
        public ValuesPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.Values(this.Navigation);
        }
    }
}
