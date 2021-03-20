using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static AnimalsFriends.Helpers.Types;

namespace AnimalsFriends.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PreviewImg { get; set; }

        //can make it class later on
        public BlogCategory Category { get; set; }

        //can make it class later on - add later
        //public List<string> Tag { get; set; }

        //Author
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        public DateTime PublishedOn { get; set; }

        //For Causes
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //For Posts
        public int? AnimalId { get; set; }        
    }
}
