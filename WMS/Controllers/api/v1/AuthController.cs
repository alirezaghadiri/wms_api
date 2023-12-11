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
using wms.Model;
using WMS.Models;
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
            _mapper = new MapperConfiguration(cfg =>
            {
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


                            return Ok("nok");
                        }
                        else
                        {
                            if (user.password == utiles.Tools.hashedPassword(model.password, user.PasswordSalt))
                            {
                              
                                TokenResponseDTO Response = new TokenResponseDTO()
                                {
                                    AccessToken = security.TokenGenretor.CreateAccessToken(user, DateTime.Now.AddDays(2)),
                                    status = true,
                                    title = "عملیلت موفق",
                                    message = "عملیات با موفقیت آنجام گردید",
                                };

                                return Ok(Response);
                            }
                            else
                            {
                                return Ok(new ReturnMessage()
                                {
                                    title = "عملیات ناموفق",
                                    message = "خطا در انجام عملیات "
                                });
                            }
                        }
                    }
                default:
                    {
                        return Ok(new ReturnMessage()
                        {
                            title = "عملیات ناموفق",
                            message = "GrantType نامعتبر "
                        });
                    }
            }


        }


    }
}
