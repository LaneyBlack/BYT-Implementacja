namespace BYT_Implementation;

public class Device
{
    
    // Fields
    protected int Id { get; init; }
    public bool IsUsed { get; set; }
    protected Session Session { get; set; }
    
    // Connections

    public readonly List<GamingPlatform> GamingPlatforms;

    public Device(List<GamingPlatform> gamingPlatforms, int id, bool isUsed, Session session)
    {
        Id = id;
        IsUsed = isUsed;
        GamingPlatforms = gamingPlatforms;
        Session = session;

        if (gamingPlatforms.Count < 1)
        {
            throw new ArgumentException("Device supposed to have at least one gaming platform.");
        }
    }
}