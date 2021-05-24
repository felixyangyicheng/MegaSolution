using AutoMapper;
using MegaSolution.Contracts;
using MegaSolution.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MegaSolution.Controllers
{
    [ApiController]
    [Route("api/Cart")]
    public class ArtistProfileController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;
        public ArtistProfileController(IHttpContextAccessor httpContextAccessor, IOfferRepository offerRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCart()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var ap = await _offerRepository.GetArtistProfileByUserId(userId);

            return Ok(_mapper.Map<ArtistProfileDTO>(ap));

        }

    }
}
