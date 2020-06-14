using Microsoft.AspNetCore.Mvc;

namespace ComplaintsApplication.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        public ComplaintController()
        {
            
        }

        // GET: api/Complaint
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Value");
        }

    }
}
