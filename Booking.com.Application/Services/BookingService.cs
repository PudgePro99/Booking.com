using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.DTOs.Bookings;
using Booking.com.Application.Interfaces;
using BookingEntity = Booking.com.Domain.Entities.Booking;
public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISaveChanges _saveChanges;

        public BookingService(
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IUserRepository userRepository,
            ISaveChanges saveChanges)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _saveChanges = saveChanges;
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto dto)
        {
            if (dto.CheckIn >= dto.CheckOut)
                throw new ArgumentException("Cдата заезда должна быть раньше даты выезда");

            var room = await _roomRepository.GetByIdAsync(dto.RoomId);

            if (room is null)
                throw new KeyNotFoundException("Номер не найден");

            var user = await _userRepository.GetByIdAsync(dto.UserId);

            if (user is null)
                throw new KeyNotFoundException("Поселенец не найден");

            var hasOverlap = await _bookingRepository.HasBookingAsync(
                dto.RoomId,
                dto.CheckIn,
                dto.CheckOut);

            if (hasOverlap)
                throw new InvalidOperationException("Номер забронирован");

            var booking = new BookingEntity
            {
                Id = Guid.NewGuid(),
                RoomId = dto.RoomId,
                UserId = dto.UserId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut
            };

            _bookingRepository.Add(booking);

            await _saveChanges.SaveChangesAsync();

            return new BookingDto
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut
            };
        }

        public async Task<BookingDto?> GetByIdAsync(Guid id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);

            if (booking is null)
                return null;

            return new BookingDto
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut
            };
        }

        public async Task<List<BookingDto>> GetByUserIdAsync(Guid userId)
        {
            var bookings = await _bookingRepository.GetByUserIdAsync(userId);

            return bookings.Select(booking => new BookingDto
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut
            }).ToList();
        }
    }
