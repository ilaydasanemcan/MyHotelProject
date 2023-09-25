using HotelProject.WebUI.Dtos.OurServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.Pkcs;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurServicePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOurServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
