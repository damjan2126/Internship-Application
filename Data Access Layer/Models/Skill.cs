using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public record Skill
    {
        public int Id { get; init; }

        public string? Name { get; init; }
    }
}
