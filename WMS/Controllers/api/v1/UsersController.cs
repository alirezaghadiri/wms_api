using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS.Models;
using dto = WMS.Models.DTO;

namespace WMS.Controllers.api.v1
{
    public class UsersController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IRepository.IUser _userRepo;
        public UsersController()
        {
            _userRepo = new Repository.UserRepository();
            _mapper  = new MapperConfiguration(cfg => {
                cfg.AddMaps(typeof(WMS.DB.AutoMapperProfiles.CustemProfiles));
            }).CreateMapper();
        }
        [jwtAuthentication("admin")]
        [Route("v1/GetUser/{id}")]
        [HttpGet]
        public IHttpActionResult Getuser(int id)
        {
            return Ok(_mapper.Map<dto.user>(_userRepo.Find(id)));
        }

        [jwtAuthentication("admin")]
        [Route("v1/GetUserByusername/{username}")]
        [HttpGet]
        public IHttpActionResult Getuser(string username)
        {
            return Ok(_mapper.Map<dto.user>(_userRepo.FindByusername(username)));
        }

        [jwtAuthentication("admin")]
        [Route("v1/GetListUser")]
        [HttpGet]
        public IHttpActionResult GetListuser()
        {
            return Ok(_mapper.Map<List<dto.user>>(_userRepo.GetAll()));
        }

        [jwtAuthentication("admin")]
        [Route("v1/addUser")]
        [HttpPost]
        public IHttpActionResult adduser(dto.user _user)
        {
            return Ok(_userRepo.Add(_mapper.Map<user>(_user)));
        }

        [jwtAuthentication("admin")]
        [Route("v1/UpdateUser")]
        [HttpPost]
        public IHttpActionResult UpdateUser(dto.user _user)
        {
            return Ok(_userRepo.Update(_mapper.Map<user>(_user)));
        }

        [jwtAuthentication("admin")]
        [Route("v1/ChangeUserState/{id}")]
        [HttpGet]
        public IHttpActionResult ChangeUserState(int id)
        {
            return Ok(_userRepo.changeState(id));
        }
    }
}
