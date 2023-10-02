using HotelProject.BussinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactCategoryController : ControllerBase
    {
        private readonly IContactCategoryService _contactCategoryService;

        public ContactCategoryController(IContactCategoryService contactCategoryService)
        {
            _contactCategoryService = contactCategoryService;
        }

        [HttpGet]
        public IActionResult GetAllContactCategory()
        {
            var values = _contactCategoryService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContactCategory(ContactCategory contactCategory)
        {
            _contactCategoryService.TInsert(contactCategory);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactCategory(int id)
        {
            var values = _contactCategoryService.TGetById(id);
            _contactCategoryService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContactCategory(ContactCategory contactCategory)
        {
            _contactCategoryService.TUpdate(contactCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetContactCategoryById(int id)
        {
            var value = _contactCategoryService.TGetById(id);
            return Ok(value);
        }
    }
}
