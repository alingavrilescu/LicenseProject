namespace LicenseProject.Api.ViewModels
{
    public class LicenseViewModel
    {
        public string LicenseType { get; set; }
        public DateTime Expiration { get; set; }
        public Guid ProductId { get; set; }
        public Guid ClientId { get; set; }
    }
}
