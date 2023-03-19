namespace UniEye.Modules.Users.App.Settings
{
    public class AzureAdOptions
    {
        public const string ConfigSection = "AzureAd";
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Domain { get; set; }
    }
}
