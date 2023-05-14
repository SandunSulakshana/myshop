using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeCotroller : ControllerBase
    {
        public string Index()
        {
            return "You are have reached outr home";
        }
    }
}
