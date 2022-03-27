using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    internal class CreateCandidateDTO
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string ContactNumber { get; init; }

        public string Email { get; init; }

        public int SkillId { get; init; }
    }
}
