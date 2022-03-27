﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public record Candidate
    {
        public Guid Id { get; init; }

        public string FullName { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string ContactNumber { get; init; }

        public string Email { get; init; }

        public int SkillsId { get; init; }

    }
}