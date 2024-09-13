namespace Application.Contracts;
public interface IEmail
{
    Task SendEmailAsync(string email, string subject, string message);
}
