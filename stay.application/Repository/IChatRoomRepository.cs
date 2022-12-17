using stay.application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stay.application.Repository
{
    public interface IChatRoomRepository
    {
        Task<IEnumerable<ChatRoom>> GetChatRooms();
        Task<ChatRoom> GetChatRoom(string uuid);
        Task<bool> AddChatRoom(ChatRoom chatroom);
        Task<bool> DeleteChatRoom(string uuid);
    }
}
