using HotelProject.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult GetAllUsersWithWorkLocation()
        {
            //var values=_appUserService.TGetList();
            var values = _appUserService.TUsersWithWokLocation();
            return Ok(values);
        }
    }
}
