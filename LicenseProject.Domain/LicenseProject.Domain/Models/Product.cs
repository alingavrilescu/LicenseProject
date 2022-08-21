namespace LicenseProject.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EncryptedPrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string PassPhase { get; set; }
        public List<Licenses> Licenses { get; set; }
    }
}
