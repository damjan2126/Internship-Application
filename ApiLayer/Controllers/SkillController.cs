using Business_Access_Layer.Services.IServices;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetAllCandidatesAsync()
        {
            var candidates = await _skillService.GetAllSkills();
            return Ok(candidates);
        }
    }
}
