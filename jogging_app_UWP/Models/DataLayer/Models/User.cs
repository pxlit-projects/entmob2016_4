using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    class User
    {
        private int id { get; }
        private string username { get; set; }
        private HashSet<Session> sessions = new HashSet<Session>();
    }
}
