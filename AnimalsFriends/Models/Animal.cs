using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static AnimalsFriends.Helpers.Types;

namespace AnimalsFriends.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        //can make it class later on
        public AnimalStatus CurrentStatus { get; set; }

        //can make it class later on
        public AnimalSpecies Species { get; set; }

        public string Description { get; set; }

        public string ProfileImg { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
