using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDemo.Model
{
    public class Contact
    {
        public String avatar { get; set; }
        public Boolean is_staff { get; set; }
        public String user_name { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String user_id { get; set; }
        public String club_name { get; set; }
        public String club_id { get; set; }
        public String location { get; set; }
        public String title { get; set; }

        public String FullName { get { return first_name + " " + last_name; } }

        public override string ToString()
        {
            return FullName;
        }

    }
}
