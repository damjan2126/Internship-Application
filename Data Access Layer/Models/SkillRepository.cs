using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly DataContext _context;

        public SkillRepository(DataContext context) : base(context)
        {
            _context = context;
        }


    }
}
