using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntMob.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("sessions")]
		public virtual HashSet<Session> Sessions { get; set; }

        [JsonIgnore]
        public static User DefaultUser = new User() { Name = "User", Password = "user" };
    }
}
