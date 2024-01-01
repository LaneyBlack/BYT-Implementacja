namespace BYT_Implementation;

public class Review
{
    // Those Exceptions that I throw here in constructors and setters, should be implemented in UI, not here
    
    // Fields
    public string Id {get; init;} // Form; "Game name"-"User Login"

    private int _rating;
    public int Rating
    {
        get => _rating;
        set
        {
            if (value is < 5 and > 0) {
                _rating = value;
            } else {
                throw new ArgumentException("Rating can be only from 0 to 5");
            }
        }
    }
    public string Description { get; set; }
    
    // Connections

    public User User { get; init; }
    public Game Game { get; init; }
    
    public Review(User user, Game game, int rating, string description)
    {
        Id = user.Login + "-" + game.Name;
        if (AllReviews.FindIndex(r => r.Id == Id) >= 0)
        {
            throw new ArgumentException("The review with this ID already exists");
        }
        
        Rating = rating;
        Description = description;
        User = user;
        Game = game;
        
        AllReviews.Add(this);
        game.Reviews.Add(this);
        user.Reviews.Add(this);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        Review? review = obj as Review;
        if (review == null) return false;
        return Equals(review);
    }

    public bool Equals(Review review)
    {
        return Id.Equals(review.Id);
    }

    public override string ToString()
    {
        return Id + ":" + Rating;
    }

    public void EditReview(){}
    
    // ---===--- Static ---===---

    public static readonly List<Review> AllReviews; // from DB

    public void PrintReviews()
    {
        foreach (var review in AllReviews)
        {
            Console.WriteLine(review);
        }
    }
}