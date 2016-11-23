using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EntMob_Uni.Services
{
    public class NavigationService
    {
        private static readonly object CreationLock = new object();
        private static NavigationService _instance;

        /// <summary>
        /// Gets the single instance of the NavigationService.
        /// </summary>
        public static NavigationService Default
        {
            get
            {
                if (_instance == null)
                {
                    lock (CreationLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NavigationService();
                        }
                    }
                }

                return _instance;
            }
        }

        private NavigationService() { }

        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }

        public void Navigate(Type sourcePage)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePage, parameter);
        }
    }
}
