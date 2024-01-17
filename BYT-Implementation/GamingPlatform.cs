namespace BYT_Implementation;

public class GamingPlatform
{
    // Fields
    public string Name { get; init; }
    
    // Connections
    public readonly List<Device> Devices = new ();
    
    public readonly List<Game> Games = new ();

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

    public GamingPlatform(string name, Device device)
    {
        Name = name;
        Devices.Add(device);
    }
}