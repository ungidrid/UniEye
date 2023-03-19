using UniEye.Modules.Notifications.Shared.Constants;

namespace UniEye.Modules.Notifications.Shared.Templates
{
    public class NotificationTemplate
    {
        public string TemplateCode { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public NotificationTemplate(string templateCode, Dictionary<string, string> parameters)
        {
            Parameters = parameters;
            TemplateCode = templateCode;
        }
    }

    public static class NotificationTemplateProvider
    {
        public static NotificationTemplate UserOnboardingTemplate(string personalEmail, string displayName, string domainName, string firstLoginPassword)
        {
            return new NotificationTemplate(
                NotificationTemplateCodes.USER_ONBOARDING_TEMPLATE,
                new Dictionary<string, string>
                {
                    [nameof(personalEmail)] = personalEmail,
                    [nameof(displayName)] = displayName,
                    [nameof(domainName)] = domainName,
                    [nameof(firstLoginPassword)] = firstLoginPassword
                }
            );
        }
    }
}
