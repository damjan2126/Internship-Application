using Business_Access_Layer.Extensions;
using Business_Access_Layer.Services.IServices;
using Common.DTOs;
using Common.Entities;
using Data_Access_Layer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services
{
    public class SkillService : ISkillService
    {
        private static int id = 3;
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<SkillDTO> CreateSkill(CreateSkillDTO skillDTO)
        {
            Skill skill = new()
            {
                Id = ++id,
                Name = skillDTO.Name,
            };

            await _repository.CreateSkill(skill);
            return skill.AsDTO();
        }

        public async Task DeleteSkill(SkillDTO skillDTO)
        {
            var skills = await _repository.GetAllSkills();

            foreach (var skill in skills)
            {
                if (skill.AsDTO().Name.Contains(skillDTO.Name))
                {
                    await _repository.DeleteSkill(skill.Id);
                }
            }
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkills()
        {
            var skills = await _repository.GetAllSkills();
            List<SkillDTO> skillList = new List<SkillDTO>();
            foreach (var skill in skills)
            {
                skillList.Add(skill.AsDTO());
            }
            return skillList;
        }
    }
}
