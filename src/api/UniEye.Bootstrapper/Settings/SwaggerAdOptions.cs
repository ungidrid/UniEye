namespace UniEye.Bootstrapper.Settings
{
    public class SwaggerAdOptions
    {
        public const string ConfigSection = "SwaggerAd";
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
        public string Scope { get; set; }
        public string ClinetId { get; set; }
    }
}
