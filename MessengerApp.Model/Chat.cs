using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Model
{
    public class Chat
    {
        public Guid Id { get; set; }
        public required string ChatName { get; set; }
        public List<User>? Users { get; set; }
    }
}
