using Common.DTOs;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Extensions
{
    public static class Extensions
    {
        public static CandidateDTO AsDTO(this Candidate candidate)
        {
            return new CandidateDTO
            {
                Fullname = candidate.FullName,
                DateOfBirth = candidate.DateOfBirth,
                ContactNumber = candidate.ContactNumber,
                Email = candidate.Email,
                SkillId = candidate.SkillsId
                
            };
        }

        public static SkillDTO AsDTO(this Skill skill)
        {
            return new SkillDTO
            {
                Name = skill.Name
            };
        }
    }
}
