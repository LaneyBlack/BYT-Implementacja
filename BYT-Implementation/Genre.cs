﻿namespace BYT_Implementation;

public class Genre
{
    public string Name { get; set; }
    public string Description { get; set; }

    public readonly List<Game> Games = new();

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
