using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AnimalsFriends.Helpers.Types;

namespace AnimalsFriends.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<Animal> Animals { get; set; }
    }
}
