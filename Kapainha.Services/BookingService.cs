using KarapinhaDAL.Repositories;
using KarapinhaDTO.Booking;
using KarapinhaDTO.BookingService;
using KarapinhaDTO.Category;
using KarapinhaShared.Repositories;
using KarapinhaShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapainha.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingRepository _repository;

        public BookingService()
        {
            _repository = new BookingRepository();
        }

        public BookingDto GetById(int id)
        {
            var booking = _repository.GetById(id);
            return BookingMappers.ToBookingDto(booking);
        }

        public IEnumerable<BookingDto> GetAll()
        {
            var bookings = _repository.GetAll();
            return bookings.Select(x => BookingMappers.ToBookingDto(x));
        }

        public IEnumerable<BookingDto> GetByUser(int userId)
        {
            var booking = _repository.GetByUser(userId);
            return booking.Select(x => BookingMappers.ToBookingDto(x));
        }

        public void CreateBooking(BookingCreateDto bookingCreateDto)
        {
            var booking = BookingMappers.CreateToBooking(bookingCreateDto);
            booking.ActivationDate = DateTime.Now.Date;
            _repository.Add(booking);
            _repository.Save();
        }

        public void DeleteBooking(int id)
        {
            var booking = _repository.GetById(id);
            try
            {
                if (booking != null)
                {
                    _repository.Delete(booking);
                    _repository.Save();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public decimal GetRevenueForDay(DateTime day)
        {
            return _repository.GetRevenueForDay(day);
        }

        public decimal GetRevenueForMonth(int month, int year)
        {
            return _repository.GetRevenueForMonth(month, year);
        }

        public decimal GetRevenueForYesterday()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            return GetRevenueForDay(yesterday);
        }

        public decimal GetRevenueForCurrentMonth()
        {
            var now = DateTime.Now;
            return GetRevenueForMonth(now.Month, now.Year);
        }

        public decimal GetRevenueForLastMonth()
        {
            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);
            return GetRevenueForMonth(lastMonth.Month, lastMonth.Year);
        }

        public void UpdateBooking(int id, BookingCreateDto bookingCreateDto)
        {
            var existingBooking = _repository.GetById(id);
            if (existingBooking == null)
                throw new KeyNotFoundException($"Booking with id {id} not found.");

            // Atualizar propriedades simples
            existingBooking.Price = bookingCreateDto.Price;
            existingBooking.UserId = bookingCreateDto.UserId;
            existingBooking.ActivationDate = DateTime.Now.Date;

            // Atualizar serviços
            existingBooking.Services = bookingCreateDto.Services.Select(serviceDto =>
            {
                var service = BookingServiceMappers.CreateToBookingService(serviceDto);
                service.BookingId = id;
                return service;
            }).ToList();

            _repository.Update(existingBooking);
            _repository.Save();
        }
        public void UpdateBookingStatus(int id, string status)
        {
            var existingBooking = _repository.GetById(id) ?? throw new KeyNotFoundException("User not found");
            existingBooking.Status = status;
            existingBooking.ActivationDate = DateTime.Now.Date;
            _repository.UpdatingSatus(existingBooking);
            _repository.Save();
        }
    }
}
