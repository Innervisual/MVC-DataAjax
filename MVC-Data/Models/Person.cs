using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
        public int Id { get; set; }

        internal bool Contains()
        {
            throw new NotImplementedException();
        }
    }

}
