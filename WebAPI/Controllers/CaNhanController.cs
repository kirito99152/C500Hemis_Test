using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaNhanController : ControllerBase
    {
        IEnumerable<string> ds = new List<string>() { "Hà Nội", "Nghệ An", "Thanh Hóa" };
        [HttpGet("Hoten")]
        public string get()
        {
            return "Họ tên : CTP";
        }
    }
}
