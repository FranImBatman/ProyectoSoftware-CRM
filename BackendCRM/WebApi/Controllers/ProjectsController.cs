using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Project;
using Application.Interfaces.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectServices _services;
       
        private readonly IMapper _mapper;

        public ProjectsController(IProjectServices services, IMapper mapper)
        {
            _services = services;
           
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of projects based on the provided filters such as project name, campaign type, client, with optional pagination parameters.
        /// </summary>
        /// <summary>
        /// Retrieves a list of projects based on the provided filters.
        /// </summary>
        /// <param name="name">Optional. Filter by project name.</param>
        /// <param name="campaign">Optional. Filter by campaign type ID.</param>
        /// <param name="client">Optional. Filter by client ID.</param>
        /// <param name="offset">Optional. Skip the specified number of records (used for pagination).</param>
        /// <param name="size">Optional. Limit the number of records returned (used for pagination).</param>
        [HttpGet("Project")]
        public async Task<IActionResult> GetProjects([FromQuery] string? name, [FromQuery] int? campaign, [FromQuery] int? client, [FromQuery] int? offset, [FromQuery] int? size)
        {  
            try
            {
                var result = await _services.GetProjects(name, campaign, client, offset, size);
                return new JsonResult(result);
            }
            catch (NegativeNumberException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
        }

        /// <summary>
        /// Retrieves detailed information about a specific project by its ID.
        /// </summary>
        [HttpGet("Project/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _services.GetById(id);
                return new JsonResult(result);
            }
            catch(InvalidProjectException ex) 
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(404, apiError);
            }
        }

        /// <summary>
        /// Creates a new project with the specified details.
        /// </summary>
        [HttpPost("Project")]      
        public async Task<IActionResult> CreateProject(ProjectRequest request)
        {
            try
            {
                var result = await _services.CreateProject(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (SameNameProjectException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(409, apiError);
            }
            catch(InvalidDateTimeException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }           
            catch (InvalidClientException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch(InvalidCampaignTypeException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch(EmptyFieldException ex)
            { 
                var apiError = new ApiError {Message = ex.Message};
                return StatusCode(400, apiError);
            }

        }

        /// <summary>
        /// Adds a new task to an existing project.
        /// </summary>
        [HttpPost("Project/{id}/tasks")]
        public async Task<IActionResult> AddTask(Guid id, TaskRequest request)
        {
            
            try
            {
                var result = await _services.AddTask(id, request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (EmptyFieldException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidUserException ex) 
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch(InvalidStatusException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
           
        }

        /// <summary>
        /// Adds a new interaction to an existing project.
        /// </summary>
        [HttpPost("Project/{id}/interactions")]
        public async Task<IActionResult> AddInteraction(Guid id, InteractionRequest request)
        {                  
            try 
            {
                var result = await _services.AddInteraction(id, request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (EmptyFieldException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidInteractionTypeException ex)  
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }

        }

        /// <summary>
        /// Updates an existing task with the specified details.
        /// </summary>
        //PUT: api/v1/Tasks/{id}
        [HttpPut("Tasks/{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, TaskRequest request)
        {
            try
            {
                var result = await _services.UpdateTask(request, id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (EmptyFieldException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidTaskException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidUserException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidStatusException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }
            catch (InvalidDateTimeException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);
            }


        }
    
    }
}
