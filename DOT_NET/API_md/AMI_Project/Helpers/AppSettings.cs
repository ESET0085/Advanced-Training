namespace AMI_Project.Helpers
{
    public class AppSettings
    {
        public string JwtSecret { get; set; } = null!;
        public int JwtExpiryMinutes { get; set; }
    }
}
