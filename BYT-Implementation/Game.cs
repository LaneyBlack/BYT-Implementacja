namespace BYT_Implementation;

public class Game
{
    // Those Exceptions that I throw here in constructors and setters, should be implemented in UI, not here

    // Fields
    public string Name { get; init; }

    protected float Price { get; set; }

    public List<string> AvailableLanguages { get; set; }

    public string Languages => String.Join(", ", AvailableLanguages.ToArray());

    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Publisher { get; set; }
    public int AgeRequirements { get; set; }

    // Connections

    public readonly List<Review> Reviews = new List<Review>(); // from DB
    
    public readonly List<Genre> Genres = new();

    public readonly List<GamingPlatform> GamingPlatforms = new();
    
    public readonly List<Client> ClientsFavorite = new();
    public readonly List<Session> Sessions = new();

    public float AverageRating
    {
        get
        {
            if (Reviews.Count != 0)
            {
                float sum = 0;
                foreach (var review in Reviews)
                {
                    sum += review.Rating;
                }

                return sum / Reviews.Count;
            }

            return -1;
        }
    }

    public Game(string name, float price, List<string> availableLanguages, string description, DateOnly releaseDate,
        string publisher, int ageRequirements, Genre genre, GamingPlatform gamingPlatform)
    {
        Name = name;
        Price = price;
        AvailableLanguages = availableLanguages;
        Description = description;
        ReleaseDate = releaseDate;
        Publisher = publisher;
        AgeRequirements = ageRequirements;
        
        Genres.Add(genre);
        GamingPlatforms.Add(gamingPlatform);
        Games.Add(this);
    }

    // Methods

    public void TurnTheGameOn(Client client)
    {
        if (client.CurrentSession != null)
            throw new ApplicationException("User is already playing.");
        var deviceToUse = (from gamingPlatform in GamingPlatforms
            from device in gamingPlatform.Devices
            where !device.IsUsed
            select device).FirstOrDefault();
        if (deviceToUse != null)
        {
            Session session = new Session(1, DateTime.Today, deviceToUse, client, this);
            client.CurrentSession = session;
            if (!client.GameSessions.ContainsKey(this))
                client.GameSessions.Add(this, new List<Session>());
            client.GameSessions[this].Add(session);
            Sessions.Add(session);
        }
    }

    public void ShowReviewsOnGame()
    {
        foreach (var review in Reviews)
        {
            Console.WriteLine(review);
        }
    }

    // ---===--- Static ---===---

    public List<Game> Games; //from DB

    public void ShowGames()
    {
        foreach (var game in Games)
        {
            Console.WriteLine(game.Name + " " + game.Price + "$ " + game.Publisher);
        }
    }

    public void ShowGamesWithTheirStatistics()
    {
        foreach (var game in Games)
        {
            Console.WriteLine(game.Name + " " + game.Price + "$ " + game.Publisher + " " + game.AverageRating);
        }
    }
}