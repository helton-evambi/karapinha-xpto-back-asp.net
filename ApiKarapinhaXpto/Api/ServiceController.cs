using Kapainha.Services;
using KarapinhaDTO.Service;
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
    public class ServiceController : ApiController
    {
        [RoutePrefix("api/services")]
        public class ServicesController : ApiController
        {
            private readonly ServiceService _serviceService;

            public ServicesController()
            {
                _serviceService = new ServiceService();
            }

            [HttpGet, Route("")]
            public IEnumerable<ServiceDto> Get()
            {
                return _serviceService.GetAll();
            }

            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var service = _serviceService.GetById(id);
                if (service == null)
                {
                    return NotFound();
                }
                return Ok(service);
            }

            [HttpGet, Route("getByCategory/{id:int}")]
            public IHttpActionResult GetByCategory(int id)
            {
                var service = _serviceService.GetByCategory(id);
                if (service == null)
                {
                    return NotFound();
                }
                return Ok(service);
            }

            [HttpGet, Route("most-requested")]
            public IHttpActionResult GetMostRequestedService()
            {
                var service = _serviceService.GetMostRequestedService();
                return Ok(service);
            }

            [HttpGet, Route("least-requested")]
            public IHttpActionResult GetLeastRequestedService()
            {
                var service = _serviceService.GetLeastRequestedService();
                return Ok(service);
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
                    var serviceCreateDto = new ServiceCreateDto
                    {
                        Name = provider.FormData["Name"],
                        Description = provider.FormData["Description"],
                        Price = decimal.Parse(provider.FormData["Price"]),
                        EstimatedTime = int.Parse(provider.FormData["EstimatedTime"]),
                        CategoryId = int.Parse(provider.FormData["CategoryId"]),
                        Image = null
                    };

                    // Obter o arquivo
                    foreach (var file in provider.FileData)
                    {
                        var fileName = Path.GetFileName(file.Headers.ContentDisposition.FileName.Trim('"'));
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                        var filePath = Path.Combine(root, uniqueFileName);
                        File.Move(file.LocalFileName, filePath);
                        serviceCreateDto.Image = "/Uploads/" + uniqueFileName;
                    }

                    // Criar Servico
                    _serviceService.CreateService(serviceCreateDto);

                    return Ok(new { message = "Categoria criada com sucesso", service = serviceCreateDto });
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
                var servicel = _serviceService.GetById(id);
                if (servicel == null)
                {
                    return NotFound();
                }

                _serviceService.DeleteService(id);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("updateStatus/{id:int}")]
            public IHttpActionResult PutStatus(int id, [FromBody] string status)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingService = _serviceService.GetById(id);
                if (existingService == null)
                {
                    return NotFound();
                }

                _serviceService.UpdateServiceStatus(id, status);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
