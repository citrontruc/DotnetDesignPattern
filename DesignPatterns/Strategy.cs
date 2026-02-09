/*
Behavioural pattern to provide multiple ways to do something.
Easy to extend by adding new implementations.
*/

public interface PayService
{
    public void Pay(int payValue);
}

public class PayByCardService : PayService
{
    public void Pay(int payValue)
    {
        Console.WriteLine("You payed by card.");
    }
}

public class PayByPaypalService : PayService
{
    public void Pay(int payValue)
    {
        Console.WriteLine("You payed by paypal.");
    }
}

public class Shop
{
    private PayService _payService;

    public Shop(PayService payService)
    {
        _payService = payService;
    }

    public void Pay(int payValue)
    {
        _payService.Pay(payValue);
    }
}

public class ShopWithInjection
{
    public void Pay(PayService payService, int payValue)
    {
        payService.Pay(payValue);
    }
}
