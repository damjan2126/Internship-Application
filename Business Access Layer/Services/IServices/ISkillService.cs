using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services.IServices
{
    public interface ISkillService
    {
        Task<SkillDTO> CreateSkill (CreateSkillDTO skillDTO);
        
        Task DeleteSkill(SkillDTO skillDTO);

        Task<IEnumerable<SkillDTO>> GetAllSkills();
    }
}
