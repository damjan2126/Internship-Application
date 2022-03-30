using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _context;

        public SkillRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Skill> Create(Skill skill)
        {
            await _context.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<int> Delete(Skill skill)
        {
            var deletedSkill = _context.Remove(skill);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            return await _context.Skills.AsNoTracking().ToListAsync();
        }

        public async Task<Skill> GetById(Guid id)
        {
            return await _context.Skills.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Skill> GetByName(string name)
        {
            return await _context.Skills.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Skill> Update(Skill skill)
        {
                var updatedSkill = _context.Skills.Update(skill);
                await _context.SaveChangesAsync();
                return updatedSkill.Entity;
        }
    }
}
