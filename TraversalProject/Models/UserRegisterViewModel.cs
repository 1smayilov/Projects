using System.ComponentModel.DataAnnotations;

namespace TraversalProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa adınızı daxil edin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa soyadınızı daxil edin")]
        public string SurName { get; set; }
        
        [Required(ErrorMessage = "Zəhmət olmasa istifadəçi adını daxil edin")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Zəhmət olmasa emailinizi daxil edin")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa şifrənizi daxil edin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa şifrənizi təkrar daxil edin")]
        [Compare("Password",ErrorMessage ="Şifrələr uyğun deyil")]
        public string ConfirmPassword { get; set; }

    }
}
