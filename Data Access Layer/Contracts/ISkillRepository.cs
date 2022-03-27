using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contracts
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllSkills();

        Task<Skill> GetSkillById(int skillId);

        Task<Skill> CreateSkill(Skill skill);

        Task DeleteSkill(int id);

        Task<Skill> SearchByName(string name);
    }
}
