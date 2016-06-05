using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensTest
{
    class User
    {
        public User() { }

        public User(string ID, string Name, long Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
    }
}
