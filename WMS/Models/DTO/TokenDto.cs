using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Models.DTO
{
    public class TokenRequestDTO
    {
        public string GrantType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string RefreshToken { get; set; }
        public bool rememberMe { get; set; }
    }
    public class TokenResponseDTO
    {
        public bool status { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}