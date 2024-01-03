namespace BYT_Implementation;

public class Device
{
    protected int id { get; init; }
    public bool isUsed { get; set; }

    public readonly List<GamingPlatform> GamingPlatforms;

    public Device(List<GamingPlatform> gamingPlatforms, int id, bool isUsed)
    {
        this.id = id;
        this.isUsed = isUsed;
        GamingPlatforms = gamingPlatforms;
        if (gamingPlatforms.Count<1)
        {
            throw new ArgumentException("Device supposed to have at least one gaming platform.");
        }
    }
}