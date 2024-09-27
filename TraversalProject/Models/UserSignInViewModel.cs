using System.ComponentModel.DataAnnotations;

namespace TraversalProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Zəhmət olmasa istifadəçi adı daxil edin")]
        public string UserName { get; set; } 
        
        
        [Required(ErrorMessage = "Zəhmət olmasa şifərinizi daxil edin")]
        public string Password { get; set; }
    }
}
