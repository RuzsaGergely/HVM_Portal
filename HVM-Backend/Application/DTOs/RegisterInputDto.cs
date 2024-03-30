using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterInputDto
    {
        // Keresztnév (cég esetén a képviselőé)
        public string FirstName { get; set; }
        // Vezetéknév (cég esetén a képviselőé)
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        // Jogi személy - Igaz ha cég vagy e.v.
        public bool IsLegalEntity { get; set; }
        // Cégnév - egyéni vállalkozó esetén az e.v. neve
        public string? CompanyName { get; set; }
        // Adószám - ha vállalkozó
        public string? VATnumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
