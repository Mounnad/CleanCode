using CleanCode.Entities;
using CleanCode.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Entities
{
    public class UserRole
    {
        public UserRoles Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
