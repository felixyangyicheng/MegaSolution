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
    public class StudiosController : ControllerBase
    {
        private readonly IStudioRepository _studioRepository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public StudiosController(IStudioRepository studioRepository,
            ILoggerService logger,
            IMapper mapper)
        {
            _studioRepository = studioRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Count studios
        [HttpGet("total")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CountStudios()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var studios =  _studioRepository.Count();
                //var response = _mapper.Map<IList<StudioDTO>>(studios);
                _logger.LogInfo($"{location}: Successful");
                return Ok(studios);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }

        }
        #endregion
        #region Get all
        /// <summary>
        /// Get all studios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudios()
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call");
                var studios = await _studioRepository.FindAll();
                var response = _mapper.Map<IList<StudioDTO>>(studios);
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
        /// Get studio by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudio(int id)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Attempted Call for id: {id}");
                var studio = await _studioRepository.FindById(id);
                if (studio == null)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var response = _mapper.Map<StudioDTO>(studio);
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
        /// Create a studio
        /// </summary>
        /// <param name="studioDTO"></param>
        /// <returns></returns>
        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] StudioCreateDTO studioDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Create Attempted");
                if (studioDTO == null)
                {
                    _logger.LogWarn($"{location}: Empty Request was submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn($"{location}: Data was Incomplete");
                    return BadRequest(ModelState);
                }
                var studio = _mapper.Map<Studio>(studioDTO);
                var isSuccess = await _studioRepository.Create(studio);
                if (!isSuccess)
                {
                    return InternalError($"{location}: Creation failed");
                }
                _logger.LogInfo($"{location}: Creation was successful");
                return Created("Create", new { studio });
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
        }

        #endregion
        #region Update
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] StudioUpdateDTO studioDTO)
        {
            var location = GetControllerActionNames();
            try
            {
                _logger.LogInfo($"{location}: Update Attempted on record with id: {id} ");
                if (id < 1 || studioDTO == null || id != studioDTO.StudioId)
                {
                    _logger.LogWarn($"{location}: Update failed with bad data - id: {id}");
                    return BadRequest();
                }
                var isExists = await _studioRepository.isExists(id);
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
                var studio = _mapper.Map<Studio>(studioDTO);
                var isSuccess = await _studioRepository.Update(studio);
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
                var isExists = await _studioRepository.isExists(id);
                if (!isExists)
                {
                    _logger.LogWarn($"{location}: Failed to retrieve record with id: {id}");
                    return NotFound();
                }
                var studio = await _studioRepository.FindById(id);
                var isSuccess = await _studioRepository.Delete(studio);
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
