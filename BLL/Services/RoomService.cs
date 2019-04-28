using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Interfaces;
using BLL.Interface.Models;
using BLL.Interface.Models.Enums;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms()
        {
            var roomsDB = this.roomRepository.GetRooms();

            var rooms = new List<Room>(roomsDB.Count());
            foreach (var room in roomsDB)
            {
                rooms.Add(new Room
                              {
                    Id = room.Id,
                    PlacesCount = room.PlacesCount,
                    DayPrice = room.DayPrice,
                    RoomType = (RoomType)Enum.Parse(typeof(RoomType), room.RoomType, true), 
                    Description = room.Description,
                    ImageURL = room.ImageURL
                              });
            }

            return rooms;
        }
    }
}
