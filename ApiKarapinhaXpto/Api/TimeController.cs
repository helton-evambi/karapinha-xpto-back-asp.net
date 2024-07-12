using Kapainha.Services;
using KarapinhaDTO.Professional;
using KarapinhaDTO.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiKarapinhaXpto.Api
{
    public class TimeController : ApiController
    {
        [RoutePrefix("api/times")]
        public class TimesController : ApiController
        {
            private readonly TimeService _timeService;

            public TimesController()
            {
                _timeService = new TimeService();
            }
            [HttpGet, Route("")]
            public IEnumerable<TimeDto> Get()
            {
                return _timeService.GetAll();
            }

            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var time = _timeService.GetById(id);
                if (time == null)
                {
                    return NotFound();
                }
                return Ok(time);
            }

            [HttpPost, Route("")]
            public IHttpActionResult Post([FromBody] TimeCreateDto timeCreateDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _timeService.CreateTime(timeCreateDto);
                return Ok();
            }

            // DELETE: api/categories/5
            [HttpDelete, Route("{id:int}")]
            public IHttpActionResult Delete(int id)
            {
                var time = _timeService.GetById(id);
                if (time == null)
                {
                    return NotFound();
                }

                _timeService.DeleteTime(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
