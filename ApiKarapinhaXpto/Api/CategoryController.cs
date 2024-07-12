using Kapainha.Services;
using KarapinhaDTO.Category;
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
    public class CategoryController : ApiController
    {
        [RoutePrefix("api/categories")]
        public class CategoriesController : ApiController
        {
            private readonly CategoryService _categoryService;

            public CategoriesController()
            {
                _categoryService = new CategoryService();
            }

            // GET: api/categories
            [HttpGet, Route("")]
            public IEnumerable<CategoryDto> Get()
            {
                return _categoryService.GetAll();
            }

            // GET: api/categories/5
            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var category = _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }

            // POST: api/categories
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
                    var categoryCreateDto = new CategoryCreateDto
                    {
                        Name = provider.FormData["Name"],
                        Description = provider.FormData["Description"],
                        Imagem = null // Será definida mais tarde
                    };

                    // Obter o arquivo
                    foreach (var file in provider.FileData)
                    {
                        var fileName = Path.GetFileName(file.Headers.ContentDisposition.FileName.Trim('"'));
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                        var filePath = Path.Combine(root, uniqueFileName);
                        File.Move(file.LocalFileName, filePath);
                        categoryCreateDto.Imagem = "/Uploads/" + uniqueFileName;
                    }

                    // Criar categoria
                    _categoryService.CreateCategory(categoryCreateDto);

                    return Ok(new { message = "Categoria criada com sucesso", category = categoryCreateDto });
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }


            // PUT: api/categories/5
            [HttpPut, Route("{id:int}")]
            public IHttpActionResult Put(int id, [FromBody] CategoryCreateDto categoryDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingCategory = _categoryService.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

               _categoryService.UpdateCategory(id, categoryDto);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("updateStatus/{id:int}")]
            public IHttpActionResult PutStatus(int id, [FromBody] string status)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingCategory = _categoryService.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                _categoryService.UpdateCategoryStatus(id, status);
                return StatusCode(HttpStatusCode.NoContent);
            }

            // DELETE: api/categories/5
            [HttpDelete, Route("{id:int}")]
            public IHttpActionResult Delete(int id)
            {
                var category = _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }

                _categoryService.DeleteCategory(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}