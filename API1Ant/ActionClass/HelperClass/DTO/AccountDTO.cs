using System.ComponentModel.DataAnnotations;

namespace API1Ant.ActionClass.HelperClass.DTO
{
    public class AccountDTO
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; internal set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
