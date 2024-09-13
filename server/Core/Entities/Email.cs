namespace Core.Entities;

public class Email
{
   public string Host { get; set; } = string.Empty;
   public int Port { get; set; } = 0;
   public string Username { get; set; } = string.Empty;
   public string Password { get; set; } = string.Empty;
}
