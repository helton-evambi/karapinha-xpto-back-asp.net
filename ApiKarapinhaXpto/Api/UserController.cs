using Kapainha.Services;
using KarapinhaDTO.Category;
using KarapinhaDTO.Time;
using KarapinhaDTO.User;
using KarapinhaShared.Exceptions;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiKarapinhaXpto.Api
{
    public class UserController : ApiController
    {
        [RoutePrefix("api/users")]
        public class UsersController : ApiController
        {
            private readonly UserService _userService;

            public UsersController()
            {
                _userService = new UserService();
            }

            [HttpGet, Route("")]
            public IEnumerable<UserDto> Get()
            {
                return _userService.GetAll();
            }

            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var user = _userService.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            
            [HttpGet, Route("email/{email}")]
            public UserDto GetByEmail(string email)
            {
                return _userService.GetByEmail(email);
            }

            [HttpGet, Route("username/{username}")]
            public UserDto GetByUsername(string username)
            {
                return _userService.GetByUsername(username);
            }
            
            [HttpPost, Route("")]
            public async Task<IHttpActionResult> Post()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return BadRequest("Unsupported media type");
                }
                

                var root = HttpContext.Current.Server.MapPath("~/Uploads");
                var provider = new MultipartFormDataStreamProvider(root);

                try
                {
                    await Request.Content.ReadAsMultipartAsync(provider);

                    // Obter dados do formulário
                    var userCreateDto = new UserCreateDto
                    {
                        FirstName = provider.FormData["FirstName"],
                        LastName = provider.FormData["LastName"],
                        Password = provider.FormData["Password"],
                        ConfirmPassword = provider.FormData["ConfirmPassword"],
                        EmailAddress = provider.FormData["EmailAddress"],
                        IdCard = provider.FormData["IdCard"],
                        PhoneNumber = int.Parse(provider.FormData["PhoneNumber"]),
                        PhotoUrl = null,
                        Role = provider.FormData["Role"],
                        Username = provider.FormData["Username"],

                    };

                    // Obter o arquivo
                    foreach (var file in provider.FileData)
                    {
                        var fileName = Path.GetFileName(file.Headers.ContentDisposition.FileName.Trim('"'));
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                        var filePath = Path.Combine(root, uniqueFileName);
                        File.Move(file.LocalFileName, filePath);
                        userCreateDto.PhotoUrl = "/Uploads/" + uniqueFileName;
                    }

                    // Criar Servico
                    if(_userService == null)
                    {
                        return BadRequest("bad request");
                    }
                    _userService.CreateUser(userCreateDto);

                    return Ok(new { message = "Utilizador criado com sucesso", user = userCreateDto });
                }
                catch (UserAlreadyExistsException)
                {
                    return Conflict();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

            // DELETE: api/categories/5
            [HttpDelete, Route("{id:int}")]
            public IHttpActionResult Delete(int id)
            {
                var user = _userService.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }

                _userService.DeleteUser(id);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("{id:int}")]
            public IHttpActionResult Put(int id, [FromBody] UserCreateDto userDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingCategory = _userService.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                _userService.UpdateUser(id, userDto);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("updateStatus/{id:int}")]
            public IHttpActionResult PutStatus(int id, [FromBody] string status)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = _userService.GetById(id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                _userService.UpdateUserStatus(id, status);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
