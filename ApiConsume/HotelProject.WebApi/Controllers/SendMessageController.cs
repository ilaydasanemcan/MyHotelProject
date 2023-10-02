using HotelProject.BussinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageServie;

        public SendMessageController(ISendMessageService sendMessageServie)
        {
            _sendMessageServie = sendMessageServie;
        }

        [HttpGet]
        public IActionResult GetAllSendMessage()
        {
            var values = _sendMessageServie.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSendMessage(SendMessage sendMessage)
        {
            _sendMessageServie.TInsert(sendMessage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageServie.TGetById(id);
            _sendMessageServie.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageServie.TUpdate(sendMessage);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessageById(int id)
        {
            var value = _sendMessageServie.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            var value = _sendMessageServie.GetSendMessageCount();
            return Ok(value);
        }
    }
}
