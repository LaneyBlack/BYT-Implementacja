namespace BYT_Implementation;

public class Payment
{
    public string Data { get; set; }
    public Client Client { get; init; }
    
    public Payment(string data, Client client)
    {
        Data = data;
        Client = client;
        client.Payments.Add(this);
    }

    public void TickPayment()
    {
        
    }
}