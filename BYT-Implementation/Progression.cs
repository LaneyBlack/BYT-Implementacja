using System.IO.Enumeration;

namespace BYT_Implementation;

public class Progression
{
    // Fields
    public string Filename { get; set; }
    public string? Nickname { get; set; }
    
    // Connection
    public Game Game { get; set; }
    public Client Client { get; set; }

    public Progression(string filename, string? nickname, Game game, Client client)
    {
        Filename = filename;
        Nickname = nickname;
        Game = game;
        Client = client;
        client.Progressions.Add(this);
    }
}