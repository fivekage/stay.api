using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stay.application.Requests.ChatRoom
{
    public class ChatRoomGetRequest
    {
        public string Uuid { get; set; }

        public ChatRoomGetRequest(string uuid)
        {
            Uuid = uuid;
        }
    }
}
