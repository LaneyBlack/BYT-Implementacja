namespace BYT_Implementation;

public class Session
{
    //Fields
    protected int Id { get; init; }
    protected int MaxLength { get; init; } // in hours
    public DateOnly ReleaseDate { get; set; }
    public int Length { get; set; } // in hours
    public bool IsOpen { get; set; }
    
    //Connections
    protected Device Device { get; set; }

    public Session(int id, DateOnly releaseDate, int length, bool isOpen, Device device)
    {
        Id = id;
        MaxLength = 6;
        ReleaseDate = releaseDate;
        Length = length;
        IsOpen = isOpen;
        Device = device;
    }
}
