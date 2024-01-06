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
    public List<Review> Reviews;
    public List<Progression> Progressions;
    public List<PaymentData> PaymentDatas;
    
    public User(string login, DateOnly birthDate, string name, string lastName)
    {
        Login = login;
        BirthDate = birthDate;
        Name = name;
        LastName = lastName;
        PaymentDatas = new List<PaymentData>();
        Reviews = new List<Review>();
        Progressions = new List<Progression>();
    }
}