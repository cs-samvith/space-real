using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Quiz.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        [HttpGet]
        public Object Get()
        {
            using (var reader = new StreamReader("./System/info.json"))
            {
                var content = reader.ReadToEnd();
                var json = JsonSerializer.Deserialize<Object>(content);
                return json;
            }
        }
    }
}
