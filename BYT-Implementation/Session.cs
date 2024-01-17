﻿namespace BYT_Implementation;

public class Session
{
    //Fields
    protected int Id { get; init; }
    protected int MaxLength { get; init; } // in hours
    public DateTime Date { get; set; }
    public int Length { get; set; } // in hours
    public bool IsOpen { get; set; }

    //Connections
    protected Device Device { get; set; }
    protected User User { get; set; }
    protected Game Game { get; set; }

    public Session(int id, DateTime date, Device device, User user, Game game)
    {
        Id = id;
        MaxLength = 6;
        Date = date;
        Length = 0;
        IsOpen = true;
        Device = device;
        device.IsUsed = true;
        User = user;
        Game = game;
    }
}
