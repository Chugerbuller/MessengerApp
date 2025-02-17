using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Model
{
    public class MessengesInChat
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid MessegeId { get; set; }
        public Chat? Chat { get; set; }
        public Messege? Messege { get; set; }
    }
}
