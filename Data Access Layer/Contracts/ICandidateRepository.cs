using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contracts
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateById(Guid id);

        Task<IEnumerable<Candidate>> GetAllCandidates();

        Task<Candidate> CreateCandidate(Candidate candidate);

        Task<Candidate> UpdateCandidate(Candidate candidate);

        Task<int> DeleteCandidate(Candidate candidate);

        Task<Candidate> GetByName(string name);

        Task<Candidate> GetByEmail(string email);

    }
}
