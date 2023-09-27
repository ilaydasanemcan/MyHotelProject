using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiViewModel> apiViewModels = new List<ApiViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "X-RapidAPI-Key", "8e76fea71amsh482e14f1c0102a6p180b9ajsn6fb9f094627b" },
                    { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                 },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiViewModels=JsonConvert.DeserializeObject<List<ApiViewModel>>(body);
                return View(apiViewModels);
            }
        }
    }
}
