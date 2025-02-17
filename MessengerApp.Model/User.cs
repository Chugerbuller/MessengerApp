using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid PersonID { get; set; }

        public Person Person { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
