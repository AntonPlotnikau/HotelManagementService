using System;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
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

        public void DeleteRoom(int id)
        {
            using (var container = new DataModelContainer())
            {
                var room = container.Rooms.FirstOrDefault(r => r.Id == id);
                container.Rooms.Remove(room);
                container.SaveChanges();
            }
        }

        public void AddRoom(Room room)
        {
            using (DataModelContainer container = new DataModelContainer())
            {
                room.Hotel = container.Hotels.FirstOrDefault();
                container.Rooms.Add(room);
                container.SaveChanges();
            }
        }

        public void UpdateRoom(Room room)
        {
            using (var container = new DataModelContainer())
            {
                var roomDB = container.Rooms.FirstOrDefault(r => r.Id == room.Id);
                roomDB.PlacesCount = room.PlacesCount;
                roomDB.RoomType = room.RoomType;
                roomDB.DayPrice = room.DayPrice;
                roomDB.Description = room.Description;
                roomDB.ImageURL = room.ImageURL;
                container.SaveChanges();
            }
        }

        public IEnumerable<Room> GetRooms(Func<Room, bool> predicate)
        {
            using (DataModelContainer container = new DataModelContainer())
            {
                return container.Rooms.Where(predicate).ToList();
            }
        }
    }
}