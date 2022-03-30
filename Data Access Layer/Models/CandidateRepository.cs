using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
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
        private readonly DataContext _context;

        public CandidateRepository(DataContext repository)
        {
            _context = repository;
        }

        public async Task<Candidate> Create(Candidate candidate)
        {
            await _context.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task<int> Delete(Candidate candidate)
        {
            var deletedCandidate = _context.Remove(candidate);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _context.Candidates.AsNoTracking().ToListAsync();
        }

        public async Task<Candidate> GetById(Guid id)
        {
            return await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Candidate> GetByEmail(string email)
        {
            return await _context.Candidates.AsNoTracking().FirstOrDefaultAsync<Candidate>(c => c.Email == email); 
        }

        public async Task<Candidate> GetByName(string name)
        {
            return await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(c => c.FullName == name);
        }

        public async Task<Candidate> Update(Candidate candidate)
        {
            var updatedCandidate = _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
            return updatedCandidate.Entity;
        }
    }
}
