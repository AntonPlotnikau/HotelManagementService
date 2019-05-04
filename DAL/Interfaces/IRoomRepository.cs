using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoomRepository
    {
        Room GetRoom(int id);

        IEnumerable<Room> GetRooms();

        void DeleteRoom(int id);

        void AddRoom(Room room);

        void UpdateRoom(Room room);

        IEnumerable<Room> GetRooms(Func<Room, bool> predicate);
    }
}
