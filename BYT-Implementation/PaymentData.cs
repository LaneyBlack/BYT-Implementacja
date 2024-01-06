namespace BYT_Implementation;

public class PaymentData
{
    public string Data { get; set; }
    public User User { get; init; }
    
    public PaymentData(string data, User user)
    {
        Data = data;
        User = user;
        user.PaymentDatas.Add(this);
    }
}