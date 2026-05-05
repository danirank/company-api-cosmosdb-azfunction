namespace Company.Core.Configurations;

public class ResendOptions
{
    public const string SectionName = "Resend";
    public string ApiToken { get; set; } = string.Empty;
    public string FromEmail { get; set; } = "onboarding@resend.dev";
    public string AppBaseUrl { get; set; } = string.Empty;
    public string InvitePath { get; set; } = "/register";
}