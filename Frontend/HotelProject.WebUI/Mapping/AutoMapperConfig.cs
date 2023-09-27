using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutUsDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.TestimonialDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto,Service>().ReverseMap();

            CreateMap<CreateServiceDto,Service>().ReverseMap();

            CreateMap<UpdateServiceDto,Service>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();

            CreateMap<ResultLoginDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutUsDto, AboutUs>().ReverseMap();

            CreateMap<UpdateAboutUsDto, AboutUs>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();

            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();

            CreateMap<CreateGuestDto, Guest>().ReverseMap();

            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

        }

    }
}
