using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class ResultLoginDto
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        public string Password { get; set; }
    }
}
