using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class PacijentUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        [MinLength(5)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public byte[] Slika { get; set; }


        public Pacijent Pacijent1 { get; set; }

    }
}
