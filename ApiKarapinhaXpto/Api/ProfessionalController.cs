using Kapainha.Services;
using KarapinhaDTO.Booking;
using KarapinhaDTO.Professional;
using KarapinhaDTO.ProfessionalTime;
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
    public class ProfessionalController : ApiController
    {
        [RoutePrefix("api/professionals")]
        public class ProfessionalsController : ApiController
        {
            private readonly ProfessionalService _professionalService;
            public ProfessionalsController() { 
                _professionalService = new ProfessionalService();
            }

            [HttpGet, Route("")]
            public IEnumerable<ProfessionalDto> Get()
            {
                return _professionalService.GetAll();
            }

            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var professional = _professionalService.GetById(id);
                if (professional == null)
                {
                    return NotFound();
                }
                return Ok(professional);
            }
            
            [HttpGet, Route("getByCategory/{id:int}")]
            public IEnumerable<ProfessionalDto> GetByCategory(int id)
            {
                return _professionalService.GetByCategory(id);
            }

            [HttpGet, Route("getByService/{id:int}")]
            public IEnumerable<ProfessionalDto> GetByService(int id)
            {
                return _professionalService.GetByService(id);
            }

            [HttpGet, Route("top5")]
            public IHttpActionResult GetTop5Professionals()
            {
                var professionals = _professionalService.GetTop5Professionals();
                return Ok(professionals);
            }

            [HttpGet, Route("getCountBooking/{id:int}")]
            public IHttpActionResult GetCountBooking (int id)
            {
                var professional = _professionalService.GetById(id);
                if (professional == null)
                {
                    return NotFound();
                }
                return Ok(_professionalService.GetCountBooking(id));
            }

            [HttpPost, Route("")]
            public async Task<IHttpActionResult> Post()
            {
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
                    var professionalCreateDto = new ProfessionalCreateDto
                    {
                        FirstName = provider.FormData["FirstName"],
                        LastName = provider.FormData["LastName"],
                        EmailAddress = provider.FormData["EmailAddress"],
                        IdCard = provider.FormData["IdCard"],
                        PhoneNumber = int.Parse(provider.FormData["PhoneNumber"]),
                        CategoryId = int.Parse(provider.FormData["CategoryId"]),
                        Times = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<ProfessionalTimeCreateDto>>(provider.FormData["Times"])
                    };

                    // Obter o arquivo
                    foreach (var file in provider.FileData)
                    {
                        var fileName = Path.GetFileName(file.Headers.ContentDisposition.FileName.Trim('"'));
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                        var filePath = Path.Combine(root, uniqueFileName);
                        File.Move(file.LocalFileName, filePath);
                        professionalCreateDto.PhotoUrl = "/Uploads/" + uniqueFileName;
                    }

                    // Passar os dados processados para o serviço
                    _professionalService.CreateProfessional(professionalCreateDto);

                    return Ok(new { message = "Professional criado com sucesso", professional = professionalCreateDto });
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
                var professional = _professionalService.GetById(id);
                if (professional == null)
                {
                    return NotFound();
                }

                _professionalService.DeleteProfessional(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
