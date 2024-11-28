using Application.DTOs.Requests;
using Application.DTOs.Response;
using Application.Exceptions;
using Application.Interfaces.Client;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _services;
        private readonly IMapper _mapper;

        public ClientsController(IClientService services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all clients.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }

        /// <summary>
        /// Creates a new client with the provided details.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientRequest request)
        {
            try
            {
                var result = await _services.CreateClient(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (EmptyFieldException ex)
            {
                var apiError = new ApiError { Message = ex.Message };
                return StatusCode(400, apiError);

            }

        }
    }

}

