﻿using System.Collections.Generic;
using BLL.Interface.Models;

namespace BLL.Interface.Interfaces
{
    public interface IRoomService
    {
        Room GetRoom(int id);

        IEnumerable<Room> GetRooms();
    }
}
