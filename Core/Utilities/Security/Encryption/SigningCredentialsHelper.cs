using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Credentials kullanıcı adı parola sisteme girmek için elde olanlar
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
            //hangi anahtar , hangi  algoritma kullanılacak asp ye onu söylüyoruz.
            //
        }
    }
}
