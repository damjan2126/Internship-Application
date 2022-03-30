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
        Task<Candidate> GetById(Guid id);

        Task<IEnumerable<Candidate>> GetAll();

        Task<Candidate> Create(Candidate candidate);

        Task<Candidate> Update(Candidate candidate);

        Task<int> Delete(Candidate candidate);

        Task<Candidate> GetByName(string name);

        Task<Candidate> GetByEmail(string email);

    }
}
