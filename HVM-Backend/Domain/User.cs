namespace Domain
{
    public class User : BaseEntity
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
        public string CompanyName { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }
        public ICollection<PowerMeter> PowerMeters { get; set; } = new List<PowerMeter>();
        // Ha operátor, akkor hozzáfér az operátori dashboardhoz
        public bool IsOperator { get; set; }
    }
}
