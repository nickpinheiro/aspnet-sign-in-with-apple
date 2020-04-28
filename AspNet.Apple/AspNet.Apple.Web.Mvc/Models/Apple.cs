using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Apple.Web.Mvc.Models
{
    public class Apple
    {
        public class User
        {
            public string Id { get; set; }
            public Name name { get; set; }
            public string email { get; set; }
        }

        public class Name
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
}
