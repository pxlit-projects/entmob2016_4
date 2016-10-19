using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EntMob_Xamarin.Models;

namespace EntMob_Xamarin.ViewModels
{
    public class ValuesViewModel
    {

        private List<Temperature> values = new List<Temperature>();

        public ValuesViewModel()
        {
            values.Add(new Temperature() { Amount = "27" });
            values.Add(new Temperature() { Amount = "25" });
            values.Add(new Temperature() { Amount = "23" });
            values.Add(new Temperature() { Amount = "21" });
            values.Add(new Temperature() { Amount = "29" });
        }



        public List<Temperature> Values
        {
            get
            {
                return values; 
            }
        }
    }
}
