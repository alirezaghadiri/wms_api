using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WMS.security;

namespace WMS
{
    public class jwtAuthentication : AuthorizationFilterAttribute
    {
        private string[] _roles;
        public jwtAuthentication(params string[] Role)
        {
            _roles = Role;
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response= actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            else
            {
                var token = actionContext.Request.Headers.Authorization.ToString().Split(' ')[1].ToString();
                if (TokenGenretor.TokenIsValid(token) == false)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                List<string> roles = TokenGenretor.GetRole(token);
                bool isRole = false;
                foreach (var role in _roles)
                    if (roles.Exists(p => p == role))
                        isRole = true;

                if (!isRole)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                else
                {
                    var identity = new GenericIdentity(TokenGenretor.GetUsername(token));
                    var principal = new GenericPrincipal(identity, roles.ToArray());
                    HttpContext.Current.User = principal;
                }

            }
            base.OnAuthorization(actionContext);
        }
    }
}