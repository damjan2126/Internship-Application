using ApiLayer.Models;
using AutoMapper;
using Business_Access_Layer.Models;

namespace ApiLayer.Mappings
{
    public static class AutoMapperAPIProfiles
    {
        public class CandidateCreateRequestProfile : Profile
        {
            public CandidateCreateRequestProfile()
            {
                CreateMap<CandidateCreateRequest, CandidateModel>();
            }
        }

        public class CandidateResponseProfile : Profile
        {
            public CandidateResponseProfile()
            {
                CreateMap<CandidateModel, CandidateResponse>();
            }
        }

        public class CandidateUpdateRequestProfile : Profile
        {
            public CandidateUpdateRequestProfile()
            {
                CreateMap<CandidateUpdateRequest, CandidateModel>();
            }
        }
    }
}
