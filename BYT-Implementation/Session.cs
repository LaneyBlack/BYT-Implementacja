namespace BYT_Implementation;

public class Session
{
    protected int Id { get; init; }
    protected int maxLength { get; init; }
    public DateOnly ReleaseDate { get; set; }
    public int Length { get; set; }//w godzinach
    public bool IsOpen { get; set; }

    protected Device Device { get; set; }

    public Session(int id, DateOnly releaseDate, int length, bool isOpen, Device device)
    {
        Id = id;
        maxLength = 6;
        ReleaseDate = releaseDate;
        Length = length;
        IsOpen = isOpen;
        Device = device;
    }
}