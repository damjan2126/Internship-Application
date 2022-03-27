using Common.Entities;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _repository;

        public CandidateRepository(DataContext repository)
        {
            _repository = repository;
        }

        public async Task<Candidate> CreateCandidate(Candidate candidate)
        {
            var result = await _repository.Candidates.AddAsync(candidate);
            await _repository.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCandidate(Guid id)
        {
            var result = await _repository.Candidates.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                _repository.Candidates.Remove(result);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return  await _repository.Candidates.ToListAsync();
        }

        public async Task<Candidate> GetCandidateById(Guid id)
        {
            return await _repository.Candidates.Include(e => e.SkillsId).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Candidate>> SearchByName(string name)
        {
            IQueryable<Candidate> query = _repository.Candidates;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FullName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            var result = await _repository.Candidates.FirstOrDefaultAsync(e => e.Id == candidate.Id);

            if (result is null)
            {
                return null;

            }

            Candidate updatedCandidate = result with
            {
                FullName = candidate.FullName,
                SkillsId = candidate.SkillsId,
                ContactNumber = candidate.ContactNumber,
                Email = candidate.Email,
                DateOfBirth = candidate.DateOfBirth
            };

            await _repository.Candidates.AddAsync(updatedCandidate);
            return updatedCandidate;

        }
    }
}
