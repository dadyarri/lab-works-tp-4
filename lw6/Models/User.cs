namespace lw6.Models;

public class User
{
    public User(string username, string password)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    public string Username { get; set; }
    public string Password { get; set; }

}