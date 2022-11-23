using BlazorSignaRTutorial.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorSignaRTutorial.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: HomeController
        [HttpGet("HomeController")]
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: HomeController/Details/5
        [HttpGet("HomeController/Details/{id}")]
        public async Task<ActionResult> Details(int id, [FromServices] MyTestProcess process)
        {

            var request = Request;

            var baseUrl = string.Format("{0}://{1}/chathub", request.Scheme, request.Host);
            await process.Start(baseUrl);

            await process.SendAsync(id);
            return Ok();
        }
    }
}
