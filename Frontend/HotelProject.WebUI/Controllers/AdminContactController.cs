using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Contact");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                await GetViewBags();
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InboxMessageDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Contact/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
                await GetViewBags();
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendBoxMessageDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/SendMessage/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSendMessageDto>(jsonData);
                await GetViewBags();
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                await GetViewBags();
                return View(values);
            }
            return View();
        }

        public PartialViewResult SideBarAdminContactPartial()
        {

            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessageAsync()
        {
            await GetViewBags();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "hotelierdeneme@gmail.com";
            createSendMessageDto.SenderName = "Hotelier";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailBoxAddress = new MailboxAddress("HotelierAdmin", "hotelierdeneme@gmail.com");
                mimeMessage.From.Add(mailBoxAddress);

                MailboxAddress mailBoxAdressTo = new MailboxAddress("User", createSendMessageDto.ReceiverMail);
                mimeMessage.To.Add(mailBoxAdressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = createSendMessageDto.Content;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = createSendMessageDto.Title;
                SmtpClient smptClient = new SmtpClient();
                smptClient.Connect("smtp.gmail.com", 587, false);
                smptClient.Authenticate("hotelierdeneme@gmail.com", "mycculwknrhqyhwx");
                smptClient.Send(mimeMessage);
                smptClient.DisconnectAsync(true);
                return RedirectToAction("Inbox", "AdminContact");
            }
            await GetViewBags();
            return View();
        }

        public async Task GetViewBags()
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7127/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7127/api/SendMessage/GetSendMessageCount");
            if (responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = jsonData3;
            }
        }
    }
}
