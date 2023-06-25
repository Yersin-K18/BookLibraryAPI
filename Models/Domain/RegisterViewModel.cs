using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.Models.Domain
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
