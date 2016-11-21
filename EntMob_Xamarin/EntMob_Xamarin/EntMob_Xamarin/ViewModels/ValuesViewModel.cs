using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EntMob.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EntMob_Xamarin.ViewModels
{
    public class ValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation navigation;
        private List<User> users;

        public ValuesViewModel()
        {
        }

        public ValuesViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public List<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                users.Add(new User() { Name = "Jonas", Password = "Allard" });
                RaisePropertyChanged("Users");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
