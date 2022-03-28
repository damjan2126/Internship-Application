using System;

namespace ApiLayer.Models
{
    public record CandidateCreateRequest
    {
        public string FullName { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string ContactNumber { get; init; }

        public string Email { get; init; }
    }
}
