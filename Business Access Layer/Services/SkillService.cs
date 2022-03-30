using AutoMapper;
using Business_Access_Layer.Models;
using Business_Access_Layer.Services.IServices;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services
{
    public class SkillService : ISkillService
    {
      
        private readonly ISkillRepository _repository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid?> Create(SkillModel skill)
        {

            var skillToCreate = _mapper.Map<Skill>(skill);
            var existis = await _repository.Find(c => c.Name.Equals(skill.Name));

            if (existis != null) return null;

            var created = await _repository.Create(skillToCreate);

            return created.Id;
        }

        public async Task<bool> Delete(Guid id)
        {

            var skillToDelete = await _repository.GetById(id);

            if (skillToDelete == null) return false;

            await _repository.Delete(skillToDelete);

            return true;
        }

        public async Task<IEnumerable<SkillModel>> GetAll()
        {
            var skills = await _repository.GetAll();

            var result = new List<SkillModel>();

            foreach (var skill in skills)
            {
                result.Add(_mapper.Map<SkillModel>(skill));
            }
            return result;
        }

        public async Task<SkillModel> GetById(Guid Id)
        {
            var skill = await _repository.GetById(Id);

            if (skill == null) return null;

            var model = _mapper.Map<SkillModel>(skill);

            return model;

        }

        public async Task<SkillModel> GetByName(string name)
        {

            var skill = await _repository.Find(c => c.Name.Equals(name));

            if (skill == null) return null;

            var model = _mapper.Map<SkillModel>(skill);

            return model;

        }

        public async Task<Skill> Update(Guid id, SkillModel model)
        {
            var skill = await _repository.GetById(id);

            if (skill == null) return null;

            skill = _mapper.Map<Skill>(model) with
            {
                    Id = id
            };

            await _repository.Update(skill, id);

            return skill;
          
        }
    }
}
