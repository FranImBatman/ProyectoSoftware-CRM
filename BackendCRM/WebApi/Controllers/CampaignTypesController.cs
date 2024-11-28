using Application.Interfaces.CampaignType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypesController : ControllerBase
    {
        private readonly ICampaignTypeService _services;

        public CampaignTypesController(ICampaignTypeService services)
        {
            _services = services;
        }

        /// <summary>
        /// Retrieves a list of all campaign types.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result); 
        }
    }
}
