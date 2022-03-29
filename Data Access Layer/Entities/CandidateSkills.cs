using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public record CandidateSkills
    {
        public Guid Id { get; init; }

        public Guid Candidate { get; init; }

        public Guid Skill { get; init; }
    }
}
