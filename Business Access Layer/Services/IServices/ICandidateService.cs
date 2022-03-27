using System;
using Common.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services.IServices
{
    public interface ICandidateService
    {
        Task<CandidateDTO> AddCandidate(CreateCandidateDTO createCandidateDTO);

        Task RemoveCandidate(CandidateDTO candidateDTO);

        Task<IEnumerable<CandidateDTO>> GetCandidatesByName(string name);

        Task UpdateCandidate(CandidateDTO candidateDTO, UpdateCandidateDTO updateCandidateDTO);

        Task<IEnumerable<CandidateDTO>> GetAllCandidatesBySkill(int id);

        Task<IEnumerable<CandidateDTO>> GetAllCandidates();
    }
}
