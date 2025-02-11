using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Data.Entities
{
    public class AuthorEntity
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
    }
}
