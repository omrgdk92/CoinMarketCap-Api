using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuClientMVC.Models
{
    public class User
    {
        [DisplayName("User Name")]
        [Required( ErrorMessage ="User name alanı boş geçilemez.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password alanı boş geçilemez.")]
        public string Password { get; set; }
        public string JwtToken { get; set; }

    }
}
