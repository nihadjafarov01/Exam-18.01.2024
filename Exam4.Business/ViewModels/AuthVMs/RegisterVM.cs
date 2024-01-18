using System.ComponentModel.DataAnnotations;

namespace Exam4.Business.ViewModels.AuthVMs
{
    public class RegisterVM
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
