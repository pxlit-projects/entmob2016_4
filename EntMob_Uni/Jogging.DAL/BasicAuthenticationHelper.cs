using Jogging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jogging.DAL
{
    class BasicAuthenticationHelper
    {

        static public AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            var value = String.Format("{0}:{1}", username, password);
            var byteArray = Encoding.ASCII.GetBytes(value);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}
