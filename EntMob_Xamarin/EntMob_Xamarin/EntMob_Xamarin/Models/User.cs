using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob_Xamarin.Models
{
    public class User
    {
        public int Id { get; }

        public string Username { get; set; }
        public string Password { get; set; }

        public HashSet<Session> Sessions { get; set; }
    }
}
