using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.DTOs.Rooms;
using Booking.com.Application.Interfaces;
using Booking.com.Domain.Entities;

namespace Booking.com.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ISaveChanges  _saveChanges;
        public RoomService(IRoomRepository roomRepository,  ISaveChanges saveChanges)
        {
            _roomRepository = roomRepository;
            _saveChanges = saveChanges;
        }

        public async Task<RoomDto?> GetByIdAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
                return null;
            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Class = room.Class,
                Price = room.Price,
                Description = room.Description
            };
            
            
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return rooms.Select(room => new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Class = room.Class,
                Price = room.Price,
                Description = room.Description
            }).ToList();
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto dto)
        {
            var room = new Room
            {
                Id = Guid.NewGuid(),
                Number = dto.Number,
                Class = dto.Class,
                Price = dto.Price,
                Description = dto.Description
            };
            _roomRepository.Add(room);
            await _saveChanges.SaveChangesAsync();
            return new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Class = room.Class,
                Price = room.Price,
                Description = room.Description
            };

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null)
                return false;
            _roomRepository.Delete(room);
            await _saveChanges.SaveChangesAsync();
            return true;
        }
        
    }
}
