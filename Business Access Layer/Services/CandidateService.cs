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
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }


        public async Task<CandidateDTO> AddCandidate(CreateCandidateDTO createCandidateDTO)
        {
            Candidate canditate = new()
            {
                Id = Guid.NewGuid(),
                FullName = createCandidateDTO.FullName,
                DateOfBirth = createCandidateDTO.DateOfBirth,
                ContactNumber = createCandidateDTO.ContactNumber,
                Email = createCandidateDTO.Email,
                SkillsId = createCandidateDTO.SkillsId
            };          

           await _repository.CreateCandidate(canditate);
            return canditate.AsDTO();

        }

        public async Task<IEnumerable<CandidateDTO>> GetAllCandidates()
        {
            var candidates = await _repository.GetAllCandidates();
            List<CandidateDTO> candidatesList = new List<CandidateDTO>();
            foreach (var candidate in candidates)
            {
                candidatesList.Add(candidate.AsDTO()); 
            }
            return candidatesList;
        }

        public async Task<IEnumerable<CandidateDTO>> GetAllCandidatesBySkill(int id)
        {
            var candidates =  await _repository.GetAllCandidates();
            List<CandidateDTO> candidatesList = new List<CandidateDTO>();
            foreach(var candidate in candidates)
            {
                if(candidate.SkillsId == id)
                {
                    candidatesList.Add(candidate.AsDTO());
                }
            }

            return candidatesList;
        }

        public async Task<IEnumerable<CandidateDTO>> GetCandidatesByName(string name)
        {
            if (name == null)
                return null;

            var candidates = await _repository.SearchByName(name);

            List<CandidateDTO> candidatesList = new List<CandidateDTO>();
            foreach (var candidate in candidates)
            {
                if (candidate.FullName.Contains(name))
                {
                    candidatesList.Add(candidate.AsDTO());
                }
            }


            return candidatesList;
        }


        public async Task RemoveCandidate(CandidateDTO candidateDTO)
        {
            var candidates = await _repository.GetAllCandidates();

            foreach(var candidate in candidates)
            {
                if(candidate.AsDTO().ContactNumber == candidateDTO.ContactNumber)
                {
                    await _repository.DeleteCandidate(candidate.Id);
                }
            }
        }

        public async Task UpdateCandidate(CandidateDTO candidateDTO, UpdateCandidateDTO updateCandidateDTO)
        {
            var candidates = await _repository.GetAllCandidates();

            foreach (var candidate in candidates)
            {
                if (candidate.AsDTO().ContactNumber == candidateDTO.ContactNumber)
                {
                    Candidate updatedCandidate = candidate with
                    {
                        FullName = updateCandidateDTO.FullName,
                        DateOfBirth = updateCandidateDTO.DateOfBirth,
                        ContactNumber = updateCandidateDTO.ContactNumber,
                        Email = updateCandidateDTO.Email,
                        SkillsId = updateCandidateDTO.SkillId
                    };

                    await _repository.UpdateCandidate(updatedCandidate);
                }
            }
        }
    }
}
