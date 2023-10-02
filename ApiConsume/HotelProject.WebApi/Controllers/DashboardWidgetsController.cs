using HotelProject.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _roomService = roomService;
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount() 
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);
        }

        [HttpGet("GetBookingGuestCount")]
        public IActionResult GetBookingGuestCount()
        {
            var value = _bookingService.TGetBookingGuestCount();
            return Ok(value);
        }

        [HttpGet("GetLast4Staff")]
        public IActionResult GetLast4Staff()
        {
            var value = _staffService.TGetLast4Staff();
            return Ok(value);
        }


        [HttpGet("GetLast6Booking")]
        public IActionResult GetLast6Booking()
        {
            var value = _bookingService.TGetLast6Booking();
            return Ok(value);
        }
    }
}
