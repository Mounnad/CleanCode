using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
