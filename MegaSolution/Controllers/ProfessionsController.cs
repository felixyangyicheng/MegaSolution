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
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ProfessionsController(IProfessionRepository professionRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _professionRepository = professionRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Count professions
        [HttpGet("total") ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CountProfessions()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var professions = _professionRepository.Count();
                //var response = _mapper.Map<IList<ProfessionDTO>>(professions);
                _logger.LogInfo($"{location}: Successful");
                return Ok(professions);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }

        }
        #endregion
        #region Get All
        /// <summary>
        /// Get all professions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProfessions()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var professions = await _professionRepository.FindAll();
                var response = _mapper.Map<IList<ProfessionDTO>>(professions);
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
        /// <summary>
        /// Get profession by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {id}");
                var profession = await _professionRepository.FindById(id);
                if (profession == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<ProfessionDTO>(profession);
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
        /// Create profession
        /// </summary>
        /// <param name="professionDTO"></param>
        /// <returns></returns>
        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProfessionCreateDTO professionDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (professionDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var profession = _mapper.Map<Profession>(professionDTO);
                var isSuccess = await _professionRepository.Create(profession);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { profession });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }
        #endregion
        #region Update
        /// <summary>
        /// Update profession
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professionDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProfessionUpdateDTO professionDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update Attempted on record with id: {id} ");
                if (id < 1 || professionDTO == null || id != professionDTO.ProfessionId)
                {
                    _logger.LogWarn($"{location}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _professionRepository.isExists(id);
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
                var profession = _mapper.Map<Profession>(professionDTO);
                var isSuccess = await _professionRepository.Update(profession);
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
                var isExists = await _professionRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var profession = await _professionRepository.FindById(id);
                var isSuccess = await _professionRepository .Delete(profession);
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
        #region Search
        // api/professions/search?keyword=john
        //Api/professions/search
        [HttpGet("{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search(string keyword)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var professions = await _professionRepository.Search(keyword);
                var response = _mapper.Map<IList<ProfessionDTO>>(professions);
                _logger.LogInfo($"{location}: Successful");
                return Ok(response);
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
