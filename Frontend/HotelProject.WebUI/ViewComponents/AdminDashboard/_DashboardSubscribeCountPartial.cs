using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;

namespace HotelProject.WebUI.ViewComponents.AdminDashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/murattycedag"),
                Headers =
                {
                    { "X-RapidAPI-Key", "8e76fea71amsh482e14f1c0102a6p180b9ajsn6fb9f094627b" },
                    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.instagramFollowers = value.followers;
                ViewBag.instagramFollowing = value.following;
            }

            //var client2 = new HttpClient();
            //var request2 = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //    RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=murattyucedag"),
            //    Headers =
            //    {
            //        { "X-RapidAPI-Key", "8e76fea71amsh482e14f1c0102a6p180b9ajsn6fb9f094627b" },
            //        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
            //    },
            //};
            //using (var response2 = await client.SendAsync(request2))
            //{
            //    response2.EnsureSuccessStatusCode();
            //    var body2 = await response2.Content.ReadAsStringAsync();
            //    var value2=JsonConvert.DeserializeObject<ResultTwitterFollowersDto> (body2);
            //    ViewBag.twitterFollowers = value2.data.user_info.followers_count;
            //    ViewBag.twitterFollowing = value2.data.user_info.friends_count;
            //}

            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmurat-y%25C3%25BCceda%25C4%259F-186933149%2F%3ForiginalSubdomain%3Dtr"),
                Headers =
            {
                { "X-RapidAPI-Key", "8e76fea71amsh482e14f1c0102a6p180b9ajsn6fb9f094627b" },
                { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
            },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                var value3=JsonConvert.DeserializeObject<ResultLinkedInFollowersDto> (body);
                ViewBag.linkedinFollowers=value3.data.followers_count;
                ViewBag.connectionCount=value3.data.connections_count;
                return View();
            }

        }

    }
}
