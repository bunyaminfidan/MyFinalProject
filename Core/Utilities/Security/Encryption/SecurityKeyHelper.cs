using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //elimizde stringi byte array haline getiriyor.
            //takeoptions içerisinde ki elimizle girdiğimiz securitykeyi byte[] haline getiriyor.
            //SymmetricSecurityKey araştır.
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
