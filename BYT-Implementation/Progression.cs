using System.IO.Enumeration;

namespace BYT_Implementation;

public class Progression
{
    // Fields
    public string Filename { get; set; }
    public string? Nickname { get; set; }
    
    // Connection
    public Game Game { get; set; }
    public User User { get; set; }

    public Progression(string filename, string? nickname, Game game, User user)
    {
        Filename = filename;
        Nickname = nickname;
        Game = game;
        User = user;
    }
}