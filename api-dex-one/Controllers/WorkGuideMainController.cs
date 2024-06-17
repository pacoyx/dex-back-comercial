using Microsoft.AspNetCore.Mvc;

namespace DexterCompany.ApiDexOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkGuideMainController : ControllerBase
    {
        private readonly IWorkGuideMainService _workGuideMain;

        public WorkGuideMainController(IWorkGuideMainService workGuideMain)
        {
            _workGuideMain = workGuideMain;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkGuideMain>>> Get()
        {
            var guias = await _workGuideMain.GetWorkGuideMains();
            return Ok(new ApiResponse { Code = 100, Message = "Guias encontradas", Data = guias });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkGuideMainDto wgmDto)
        {
            var createdWorkGuideMain = await _workGuideMain.AddWorkGuideMain(wgmDto);
            return Ok(new ApiResponse { Code = 100, Message = "Guias registrada", Data = createdWorkGuideMain.AsWorkGuideMain() });
        }
    }
}