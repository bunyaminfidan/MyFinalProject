using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //kullancı api üzerinden bunları bize gönderecek
        public string Token { get; set; }
        public DateTime Expiration { get; set; } 
        //ne zaman sonlanacak kaç dakika sonra

    }
}
