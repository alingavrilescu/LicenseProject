namespace LicenseProject.Infrastructure.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EncryptedPrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string PassPhase { get; set; }
    }
}
