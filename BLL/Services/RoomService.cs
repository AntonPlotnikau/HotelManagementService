﻿using System;
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
            var roomsDB = this.roomRepository.GetRoom(id);

            return new Room
                       {
                           Id = roomsDB.Id,
                           PlacesCount = roomsDB.PlacesCount,
                           Description = roomsDB.Description,
                           DayPrice = roomsDB.DayPrice,
                           ImageURL = roomsDB.ImageURL,
                           RoomType = (RoomType)Enum.Parse(typeof(RoomType), roomsDB.RoomType, true)
            };
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

        public void DeleteRoom(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRoom(Room room)
        {
            this.roomRepository.AddRoom(new DAL.Room
                                            {
                    Id = room.Id,
                    PlacesCount = room.PlacesCount,
                    DayPrice = room.DayPrice,
                    RoomType = room.RoomType.ToString(),
                    Description = room.Description,
                    ImageURL = room.ImageURL
                            });
        }
    }
}
