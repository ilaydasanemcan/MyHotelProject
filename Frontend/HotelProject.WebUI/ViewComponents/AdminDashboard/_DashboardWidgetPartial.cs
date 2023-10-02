using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.AdminDashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var client2 =_httpClientFactory.CreateClient();
            var client3 =_httpClientFactory.CreateClient();
            var client4 =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/DashboardWidgets/GetStaffCount");
            var responseMessage2 = await client2.GetAsync("https://localhost:7127/api/DashboardWidgets/GetBookingCount");
            var responseMessage3 = await client3.GetAsync("https://localhost:7127/api/DashboardWidgets/GetRoomCount");
            var responseMessage4 = await client4.GetAsync("https://localhost:7127/api/DashboardWidgets/GetBookingGuestCount");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode && responseMessage4.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var jsonData2=await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3=await responseMessage3.Content.ReadAsStringAsync();
                var jsonData4=await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.staffCount = jsonData;
                ViewBag.bookingCount = jsonData2;
                ViewBag.roomCount = jsonData3;
                ViewBag.bookingGuestCount = jsonData4;
                return View();
            }
            return View();
        }
    }
}
