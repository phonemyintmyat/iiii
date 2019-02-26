using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iiii.Models;
using Microsoft.Web.WebPages.OAuth;
namespace iiii
{
    public class AuthConfig
    {
        public static void RegisterAuth()
        {
            OAuthWebSecurity.RegisterFacebookClient(
               appId: "532581317150236",
               appSecret: "259b3d8b59bbbb77745de1c20609013a"
               );
        }
    }
}