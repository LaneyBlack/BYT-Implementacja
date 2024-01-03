namespace BYT_Implementation;

public class GamingPlatform
{
    // Fields
    public string Name { get; init; }
    
    // Connections
    public readonly List<Device> Devices;
    public readonly List<Game> Games;

    public int NumberOfAllDevices => Devices.Count;

    public int NumberOfUsedDevices
    {
        get
        {
            int counter = 0;
            foreach (var device in Devices)
            {
                if (device.IsUsed)
                {
                    counter++;
                }
            }
            return counter;
        }
    }

    public GamingPlatform(List<Device> devices, string name)
    {
        Devices = devices;
        Name = name;
        if (devices.Count < 1)
            throw new ArgumentException("There are no devices connected to the gaming platform.");
        
        Games = new List<Game>();
    }
}