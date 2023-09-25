using HotelProject.BussinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult GetAllAbout()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(AboutUs aboutUs)
        {
            _aboutService.TInsert(aboutUs);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(AboutUs aboutUs)
        {
            _aboutService.TUpdate(aboutUs);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
