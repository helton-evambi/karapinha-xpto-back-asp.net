using Kapainha.Services;
using KarapinhaDTO.Booking;
using KarapinhaDTO.Category;
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
    public class BookingController : ApiController
    {
        [RoutePrefix("api/bookings")]
        public class BookingsController : ApiController
        {
            private readonly BookingService _bookingService;

            public BookingsController()
            {
                _bookingService = new BookingService();
            }

            [HttpGet, Route("")]
            public IEnumerable<BookingDto> Get()
            {
                return _bookingService.GetAll();
            }

            [HttpGet, Route("{id:int}")]
            public IHttpActionResult Get(int id)
            {
                var booking = _bookingService.GetById(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
            }

            [HttpGet, Route("getByUser/{user:int}")]
            public IHttpActionResult GetByUser(int user)
            {
                var booking = _bookingService.GetByUser(user);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
            }

            [HttpPost, Route("")]
            public IHttpActionResult Post([FromBody] BookingCreateDto bookingCreateDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _bookingService.CreateBooking(bookingCreateDto);
                return Ok();
            }

            // DELETE: api/categories/5
            [HttpDelete, Route("{id:int}")]
            public IHttpActionResult Delete(int id)
            {
                var booking = _bookingService.GetById(id);
                if (booking == null)
                {
                    return NotFound();
                }

                _bookingService.DeleteBooking(id);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("{id:int}")]
            public IHttpActionResult Put(int id, [FromBody] BookingCreateDto bookingDto)
            {
               /* if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                } */

                var existingBooking = _bookingService.GetById(id);
                if (existingBooking == null)
                {
                    return NotFound();
                }

                _bookingService.UpdateBooking(id, bookingDto);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpPut, Route("updateStatus/{id:int}")]
            public IHttpActionResult PutStatus(int id, [FromBody] string status)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingBooking = _bookingService.GetById(id);
                if (existingBooking == null)
                {
                    return NotFound();
                }

                _bookingService.UpdateBookingStatus(id, status);
                return StatusCode(HttpStatusCode.NoContent);
            }

            [HttpGet, Route("revenue/today")]
            public IHttpActionResult GetRevenueForToday()
            {
                var revenue = _bookingService.GetRevenueForDay(DateTime.Today);
                return Ok(revenue);
            }

            [HttpGet, Route("revenue/yesterday")]
            public IHttpActionResult GetRevenueForYesterday()
            {
                var revenue = _bookingService.GetRevenueForYesterday();
                return Ok(revenue);
            }

            [HttpGet, Route("revenue/current-month")]
            public IHttpActionResult GetRevenueForCurrentMonth()
            {
                var revenue = _bookingService.GetRevenueForCurrentMonth();
                return Ok(revenue);
            }

            [HttpGet, Route("revenue/last-month")]
            public IHttpActionResult GetRevenueForLastMonth()
            {
                var revenue = _bookingService.GetRevenueForLastMonth();
                return Ok(revenue);
            }
        }
    }
    
}
