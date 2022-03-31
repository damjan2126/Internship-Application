using System;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context;
        private GenericRepository<Candidate> candidateRepository;
        private GenericRepository<Skill> skillRepository;

        public GenericRepository<Candidate> CandidateRepository
        {
            get
            {

                if (this.CandidateRepository == null)
                {
                    //this.CandidateRepository = new GenericRepository<Candidate>(context);
                }
                return CandidateRepository;
            }
        }

        public GenericRepository<Skill> SkillRepository
        {
            get
            {

                if (this.SkillRepository == null)
                {
                   //this.SkillRepository = new GenericRepository<Skill>(context);
                }
                return SkillRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
