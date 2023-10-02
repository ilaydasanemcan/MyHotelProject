using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.AdminDashboard
{
    public class _DashboardScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
