namespace BYT_Implementation;

public class Client
{
    // Fields
    public string Login {get; init;}

    public DateOnly BirthDate { get; init; }
    public int Age
    {
        get
        {
            var age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate.Month < DateTime.Today.Month)
                age--;
            return age;
        }
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    
    // Connections
    public List<Game> FavouritesList = new();
    public List<Review> Reviews = new();
    public List<Progression> Progressions = new();
    public List<Payment> Payments = new();
    public Dictionary<Game,List<Session>> GameSessions = new();
    public Session CurrentSession;
    
    public Client(string login, DateOnly birthDate, string name, string lastName, Payment payment)
    {
        Login = login;
        BirthDate = birthDate;
        Name = name;
        LastName = lastName;
        
        Payments.Add(payment);
    }
    
    // Methods
    
    public void EditProfile() {
        
    }

    public void TickPayment(int paymentId) {
        Payments[paymentId].TickPayment();
    }

    public void ShowWishList()
    {
        
    }
    
    // ---===--- Static ---===---

    public static void ShowProfile(string login)
    {
        
    }
}