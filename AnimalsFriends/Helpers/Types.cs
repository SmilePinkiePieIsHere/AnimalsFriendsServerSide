using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Helpers
{
    public class Types
    {
        public enum AnimalStatus
        {
            NeedHome,
            Adopted,
            InMedicalCare
        }

        public enum AnimalSpecies
        {
            Dog,
            Cat
        }

        public enum UserRole
        {
            Admin,
            User
        }

        public enum BlogCategory
        {
            News,
            Causes
        }

        public enum Gender
        {
            Male,
            Female
        }
    }
}
