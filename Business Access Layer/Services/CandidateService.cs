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
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;

        public CandidateService()
        {
        }

        public CandidateService(ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid?> Create(CandidateModel model)
        {
            var candidate = _mapper.Map<Candidate>(model);
            var existis = await _repository.Find(c => c.Email.Equals(model.Email));

            if (existis != null) return null;

            var created = await _repository.Create(candidate);

            return created.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var candidate = await _repository.GetById(id);

            if(candidate == null) return false;

            await _repository.Delete(candidate);

            return true;
        }

        public async Task<IEnumerable<CandidateModel>> GetAll()
        {
            var candidates = await _repository.GetAll();

            List<CandidateModel> result = new List<CandidateModel>();

            foreach(var candidate in candidates)
            {
                result.Add((CandidateModel)_mapper.Map<CandidateModel>(candidate));
            }
            return result;
            
        }

        public async Task<CandidateModel> GetById(Guid id)
        {
            try
            {
                var candidate = await _repository.GetById(id);

                if (candidate == null) throw new Exception();

                var model = _mapper.Map<CandidateModel>(candidate);

                return model;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<CandidateModel> GetByName(string name)
        {
            try
            {
                var candidate = await _repository.Find(c => c.FullName.Equals(name));

                if (candidate == null) throw new Exception();

                var model = _mapper.Map<CandidateModel>(candidate);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Candidate> Update(Guid id, CandidateModel model)
        {
            try
            {
                var candidate = await _repository.GetById(id);         

                if (candidate == null) throw new Exception();

                candidate = _mapper.Map<Candidate>(model) with
                {
                    Id = id
                };

                await _repository.Update(candidate, id);

                return candidate;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
