namespace BYT_Implementation;

public class Device
{
    
    // Fields
    protected int Id { get; init; }
    public bool IsUsed { get; set; }
    public List<Session> Sessions = new();
    
    // Connections

    public readonly List<GamingPlatform> GamingPlatforms = new();

    public Device(int id, bool isUsed, GamingPlatform gamingPlatform)
    {
        Id = id;
        IsUsed = isUsed;
        GamingPlatforms.Add(gamingPlatform);
    }
}