namespace eClinica.Core.Configuration
{
    public class ApplicationOptions
    {
        public static string Section = "Application";
        
        public string AvatarDefault { get; set; }

        public string AppId { get; set; }
        public string ApiTalkJsUrl { get; set; }
        public string SecretKey { get; set; }
    }
}