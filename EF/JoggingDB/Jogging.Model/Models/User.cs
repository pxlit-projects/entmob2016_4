using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model.Models
{
   public class User
    {
        public int Id { get; set; }

        public string Password { get; set; }
        public string Username { get; set; }
        public HashSet<Session> Sessions = new HashSet<Session>();
    }
}
