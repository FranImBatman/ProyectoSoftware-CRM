using Application.Interfaces.TaskStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusService _services;

        public TaskStatusController(ITaskStatusService services)
        {
            _services = services;
        }

        /// <summary>
        /// Retrieves a list of all task statuses.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }
    }
}
