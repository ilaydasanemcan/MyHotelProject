using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppRoleDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
           _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values=_roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateAppRoleDto createAppRoleDto)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = createAppRoleDto.Name
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=> x.Id==id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateAppRoleDto updateAppRoleDto = new UpdateAppRoleDto()
            {
                Id=value.Id,
                Name=value.Name
            };
            return View(updateAppRoleDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateAppRoleDto updateAppRoleDto)
        {
            var value=_roleManager.Roles.FirstOrDefault(x => x.Id==updateAppRoleDto.Id);
            value.Name=updateAppRoleDto.Name;
            var result=await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
