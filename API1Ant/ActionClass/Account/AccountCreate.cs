using System.ComponentModel.DataAnnotations;

namespace API1Ant.ActionClass.Account
{
    public class AccountCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
