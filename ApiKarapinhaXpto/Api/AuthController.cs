using Kapainha.Services;
using KarapinhaDTO.User;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiKarapinhaXpto.Api
{
    public class AuthController : ApiController
    {
        [RoutePrefix("api/auth")]
        public class AuthsController : ApiController
        {
            private readonly AuthService _authService;

            public AuthsController()
            {
                _authService = new AuthService();
            }

            [HttpPost, Route("login")]
            public IHttpActionResult Login([FromBody] LoginDto loginDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _authService.Authenticate(loginDto.Identifier, loginDto.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user);
            }
        }

    }
}
