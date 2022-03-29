using ApiLayer.Models;
using AutoMapper;
using Business_Access_Layer.Models;
using Business_Access_Layer.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : BaseController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService, IMapper mapper) : base(mapper)
        {
            _candidateService = candidateService;
        }


        [HttpGet("getallcandidates")]
        public async Task<IActionResult> GetAll()
        {
            var modelList = await _candidateService.GetAll();
            var responseList = new List<CandidateResponse>();

            foreach (var model in modelList)
            {
                responseList.Add(_mapper.Map<CandidateResponse>(model));
            }
            return Ok(responseList); 
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("getcandidatebyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var model = await _candidateService.GetById(id);
            var candidateResponse = _mapper.Map<CandidateResponse>(model);
            return Ok(candidateResponse);
        }

        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost("createcandidate")]
        public async Task<IActionResult> Create([FromBody] CandidateCreateRequest createReqBody)
        {
            var candidateModel = _mapper.Map<CandidateModel>(createReqBody);
            var createdId = await _candidateService.CreateCandidate(candidateModel);

            return createdId == null ? (IActionResult)BadRequest() : CreatedAtAction(nameof(GetById), new { id = "Guid" }, createdId);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpDelete("deletecandidate/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _candidateService.DeleteCandidate(id);

            return result ? (IActionResult)Ok() : NotFound();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPut("updatecandidate/{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] Guid id, [FromBody] CandidateUpdateRequest candidateUpdateRequest)
        {
            var currentCandidate = await _candidateService.GetById(id);
            
            if(currentCandidate == null) return NotFound();

            return Ok(await _candidateService.UpdateCandidate(id, _mapper.Map<CandidateModel> (candidateUpdateRequest)));

            



            
        }


    }
}
