﻿using System;
using DAL.Interfaces;

namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class RoomRepositories : IRoomRepository
    {
        public Room GetRoom(int id)
        {
            using (DataModelContainer container = new DataModelContainer())
            {
                var room = container.Rooms.FirstOrDefault(r => r.Id == id);

                return room;
            }
        }

        public IEnumerable<Room> GetRooms()
        {
            using (DataModelContainer container = new DataModelContainer())
            {
                var rooms = container.Rooms;

                return rooms.ToList();
            }
        }
    }
}
