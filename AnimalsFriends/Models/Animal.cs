﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static AnimalsFriends.Helpers.Classes;
namespace AnimalsFriends.Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
        
        public string CurrentStatus { get; set; }
        
        public string Species { get; set; }
       
        public string Description { get; set; }

        public string ProfileImg { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
