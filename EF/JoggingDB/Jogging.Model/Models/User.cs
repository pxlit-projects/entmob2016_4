using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.Model.Models
{
   public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public HashSet<Session> Sessions = new HashSet<Session>();
    }
}
