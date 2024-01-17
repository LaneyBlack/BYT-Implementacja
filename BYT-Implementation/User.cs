namespace BYT_Implementation;

public class User
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
    public List<Game> Wishlist = new();
    public List<Review> Reviews = new();
    public List<Progression> Progressions = new();
    public List<PaymentData> PaymentDatas = new();
    public Dictionary<Game,List<Session>> GameSessions = new();
    public Session CurrentSession;
    
    public User(string login, DateOnly birthDate, string name, string lastName, PaymentData paymentData)
    {
        Login = login;
        BirthDate = birthDate;
        Name = name;
        LastName = lastName;
        
        PaymentDatas.Add(paymentData);
    }
    
    // Methods
    
    public void EditProfile() {
        
    }

    public void TickPayment(int paymentId) {
        PaymentDatas[paymentId].TickPayment();
    }

    public void ShowWishList()
    {
        
    }
    
    // ---===--- Static ---===---

    public static void ShowProfile(string login)
    {
        
    }
}