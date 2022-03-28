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

        public async Task<Guid> Create(SkillModel skill)
        {
            try
            {
                var skillToCreate = _mapper.Map<Skill>(skill);
                var existis = await _repository.GetByName(skill.Name);

                if (existis != null) throw new Exception(); // implement custom exception

                var created = await _repository.Create(skillToCreate);

                return created.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var skillToDelete = await _repository.GetById(id);

                if (skillToDelete == null) throw new Exception();

                await _repository.Delete(skillToDelete);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                var skill = await _repository.GetById(Id);

                if (skill == null) throw new Exception();

                var model = _mapper.Map<SkillModel>(skill);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SkillModel> GetByName(string name)
        {
            try
            {
                var skill = await _repository.GetByName(name);

                if (skill == null) throw new Exception();

                var model = _mapper.Map<SkillModel>(skill);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
