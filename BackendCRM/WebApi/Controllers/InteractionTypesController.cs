using Application.Interfaces.InteractionType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypeService _services;

        public InteractionTypesController(IInteractionTypeService services)
        {
            _services = services;
        }

        /// <summary>
        /// Retrieves a list of all interaction types.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);  
        }
    }
}
