using AutoMapper;
using MegaSolution.Contracts;
using MegaSolution.Data;
using MegaSolution.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProfessionSectorsController : ControllerBase
    {

        private readonly IProfessionSectorRepository _professionSectorRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ProfessionSectorsController(IProfessionSectorRepository professionSectorRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _professionSectorRepository = professionSectorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #region Count sectors
        [HttpGet("total")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CountProfessionSectors()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var professionSectors =  _professionSectorRepository.Count();
                //var response = _mapper.Map<IList<ProfessionSectorDTO>>(professionSectors);
                _logger.LogInfo($"{location}: Successful");
                return Ok(professionSectors);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }

        }
        #endregion

        #region  Get All 
        /// <summary>
        /// Get all ProfessionSectors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProfessionSectors()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var professionSectors = await _professionSectorRepository.FindAll();
                var response = _mapper.Map<IList<ProfessionSectorDTO>>(professionSectors);
                _logger.LogInfo($"{location}: Successful");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }

        }
        #endregion
        #region Get by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProfessionSector(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {id}");
                var professionSector = await _professionSectorRepository.FindById(id);
                if (professionSector == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<ProfessionSectorDTO>(professionSector);
                _logger.LogInfo($"{location}: Successfully got record with id: {id}");
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        #endregion
        #region Create
        /// <summary>
        /// Create a sector
        /// </summary>
        /// <param name="professionSectorDTO"></param>
        /// <returns></returns>
        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProfessionSectorCreateDTO professionSectorDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (professionSectorDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var professionSector = _mapper.Map<ProfessionSector>(professionSectorDTO);
                var isSuccess = await _professionSectorRepository.Create(professionSector);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { professionSector });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// Update sector
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professionSectorDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProfessionSectorUpdateDTO professionSectorDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update Attempted on record with id: {id} ");
                if (id < 1 || professionSectorDTO == null || id != professionSectorDTO.ProfessionSectorId)
                {
                    _logger.LogWarn($"{location}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _professionSectorRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var professionSector = _mapper.Map<ProfessionSector>(professionSectorDTO);
                var isSuccess = await _professionSectorRepository.Update(professionSector);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Update failed for record with id: {id}");
                }
                _logger.LogInfo($"{location}: Record with id: {id} successfully updated");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Delete Attempted on record with id: {id} ");
                if (id < 1)
                {
                    _logger.LogWarn($"{location}: Delete failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _professionSectorRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var professionSector = await _professionSectorRepository.FindById(id);
                var isSuccess = await _professionSectorRepository.Delete(professionSector);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Delete failed for record with id: {id}");
                }
                _logger.LogInfo($"{location}: Record with id: {id} successfully deleted");
                return NoContent();
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        #endregion


        private string GetControllerActionNames()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} - {action}";
        }

        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong. Please contact the Administrator");
        }
    }
}
