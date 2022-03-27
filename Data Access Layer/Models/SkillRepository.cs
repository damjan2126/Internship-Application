using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _repository;

        public SkillRepository(DataContext repository)
        {
            _repository = repository;
        }

        public async Task<Skill> CreateSkill(Skill skill)
        {
            var result = await _repository.Skills.AddAsync(skill);
            await _repository.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteSkill(int id)
        {
            var result = await _repository.Skills.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _repository.Skills.Remove(result);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            return await _repository.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillById(int skillId)
        {
            return await _repository.Skills.FirstOrDefaultAsync(e => e.Id == skillId);
        }

        public async Task<Skill> SearchByName(string name)
        {
            IQueryable<Skill> query = _repository.Skills;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
