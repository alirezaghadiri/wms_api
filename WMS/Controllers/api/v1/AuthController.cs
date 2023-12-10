using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using WMS.Auth;
using WMS.Models;
using WMS.Models.DTO;
using dto = WMS.Models.DTO;

namespace WMS.Controllers.api.v1
{
    public class AuthController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IRepository.IUser _userRepo;
        public AuthController()
        {
            _userRepo = new Repository.UserRepository();
            _mapper  = new MapperConfiguration(cfg => {
                cfg.AddMaps(typeof(WMS.DB.AutoMapperProfiles.CustemProfiles));
            }).CreateMapper();
        }

        [Route("v1/Login")]
        [HttpPost]
        public IHttpActionResult Login(TokenRequestDTO model)
        {
            switch (model.GrantType)
            {
                case "user_pass":
                    {
                        var user = _userRepo.FindByusername(model.username);
                        if (user == null)
                        {

                            AuthenticationHeaderValue authorization = request.Headers.Authorization;
                            return Ok("nok");
                        }
                        else
                        {
                            if (user.password == utiles.Tools.hashedPassword(model.password, user.PasswordSalt))
                            {

                                var identity = new GenericIdentity(user.username);
                                var roles = user.Roles.Select(p => p.Title).ToArray();
                                var principal = new GenericPrincipal(identity, roles);
                                HttpContext.Current.User = principal;
                                return Ok("ok");
                            }
                            else
                            {
                                return Ok("nok");
                            }
                        }
                    }
                default: { return BadRequest(" bad GrantType"); }
            }

            
        }

      
    }
}
