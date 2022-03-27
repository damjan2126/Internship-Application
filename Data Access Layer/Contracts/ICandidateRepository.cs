using Data_Access_Layer.Models;
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

        Task DeleteCandidate(Guid id);

        Task<IEnumerable<Candidate>> SearchByName(string name);

    }
}
