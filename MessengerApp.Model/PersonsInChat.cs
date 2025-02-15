using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Model
{
    public class PersonsInChat
    {
        public Guid ChatId { get; set; }
        public Guid PersonId { get; set; }
        public Chat Chat { get; set; }
        public Person Person { get; set; }
    }
}
