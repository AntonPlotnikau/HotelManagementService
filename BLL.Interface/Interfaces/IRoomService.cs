using System.Collections.Generic;
using BLL.Interface.Models;

namespace BLL.Interface.Interfaces
{
    public interface IRoomService
    {
        Room GetRoom(int id);

        IEnumerable<Room> GetRooms();

        void DeleteRoom(int id);

        void AddRoom(Room room);

        void UpdateRoom(Room room);
    }
}
