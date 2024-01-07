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

    public readonly List<Review> Reviews; // from DB

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

    public readonly List<Genre> Genres;

    public readonly List<GamingPlatform> GamingPlatforms;

    public Game(string name, float price, List<string> availableLanguages, string description, DateOnly releaseDate,
        string publisher, int ageRequirements, List<Genre> genres, List<GamingPlatform> gamingPlatforms)
    {
        Name = name;
        Price = price;
        AvailableLanguages = availableLanguages;
        Description = description;
        ReleaseDate = releaseDate;
        Publisher = publisher;
        AgeRequirements = ageRequirements;
        if (genres.Count < 1)
            throw new ArgumentException("The game cannot have no genre");
        Genres = genres;
        if (gamingPlatforms.Count > 1)
            GamingPlatforms = gamingPlatforms;

        Reviews = new List<Review>();

        Games.Add(this);

        foreach (var genre in Genres)
        {
            genre.Games.Add(this);
        }

        foreach (var gamingPlatform in GamingPlatforms)
        {
            gamingPlatform.Games.Add(this);
        }
    }

    // Methods

    public void TurnTheGameOn(User user)
    {
        if (user.CurrentSession != null)
            throw new ApplicationException("User is already playing.");
        var deviceToUse = (from gamingPlatform in GamingPlatforms
            from device in gamingPlatform.Devices
            where !device.IsUsed
            select device).FirstOrDefault();
        if (deviceToUse != null)
        {
            Session session = new Session(1, DateTime.Today, deviceToUse);
            user.CurrentSession = session;
            if (!user.GameSessions.ContainsKey(this))
                user.GameSessions.Add(this, new List<Session>());
            user.GameSessions[this].Add(session);
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