using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contracts
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAll();

        Task<Skill> GetById(Guid Id);

        Task<Skill> Create(Skill skill);

        Task<int> Delete(Skill skill);

        Task<Skill> Update(Skill skill);

        Task<Skill> GetByName(string name);
    }
}
