/*
Bridge pattern: you let a central package compute the results.
You just bring him all the information so he can do it.
*/

public interface IBillingService
{
    public int ComputePrice();
}

public class BillingService : IBillingService
{
    private ICart _cart;
    private IShippingService _shippingService;
    private IDiscountService _discountService;

    public BillingService(
        ICart cart,
        IShippingService shippingService,
        IDiscountService discountService
    )
    {
        _cart = cart;
        _shippingService = shippingService;
        _discountService = discountService;
    }

    public int ComputePrice()
    {
        int initialPrice = _cart.GetCartPrice();
        int priceWithShipping = _shippingService.GetShippingPrice(initialPrice);
        int priceWithDiscount = _discountService.ApplyDiscount(priceWithShipping);
        return priceWithDiscount;
    }
}

public interface IShippingService
{
    public int GetShippingPrice(int cartValue);
}

public interface ICart
{
    public int GetCartPrice();
}

public interface IDiscountService
{
    public int ApplyDiscount(int price);
}

public class Cart : ICart
{
    private int _price;

    public Cart(int price)
    {
        _price = price;
    }

    public int GetCartPrice()
    {
        return _price;
    }
}

public class FrenchDiscountService : IShippingService
{
    private int _shippingPrice = 5;

    public int GetShippingPrice(int cartValue)
    {
        return _shippingPrice;
    }
}

public class FreeOverThresholdDiscountService : IShippingService
{
    private int _shippingPrice = 8;
    private int _freeShippingThreshold = 30;

    public int GetShippingPrice(int cartValue)
    {
        return cartValue > _freeShippingThreshold ? 0 : _shippingPrice;
    }
}

public class ValueBasedDiscountService : IDiscountService
{
    protected int _discountValue;

    public ValueBasedDiscountService(int discountValue)
    {
        _discountValue = discountValue;
    }

    public int ApplyDiscount(int value)
    {
        return Math.Max(0, value - _discountValue);
    }
}

public class PercentBasedDiscountService : IDiscountService
{
    protected int _discountValue;

    public PercentBasedDiscountService(int discountValue)
    {
        _discountValue = discountValue;
    }

    public int ApplyDiscount(int value)
    {
        value *= (100 - _discountValue) / 100;
        return value;
    }
}
