/*
A script to implement the factory design pattern.
Creational pattern.
When we need to instantiate a class and we don't want the elements to know the underlying logic.
*/

namespace DesignPattern;

public enum DiscountType
{
    Percentage,
    Value,
}

public abstract class DiscountService
{
    public abstract int ApplyDiscount(int value);
}

public class ValueBasedDiscountService : DiscountService
{
    protected int _discountValue;

    public ValueBasedDiscountService(int discountValue)
    {
        _discountValue = discountValue;
    }

    public override int ApplyDiscount(int value)
    {
        return Math.Max(0, value - _discountValue);
    }
}

public class PercentBasedDiscountService : DiscountService
{
    protected int _discountValue;

    public PercentBasedDiscountService(int discountValue)
    {
        _discountValue = discountValue;
    }

    public override int ApplyDiscount(int value)
    {
        value *= (100 - _discountValue) / 100;
        return value;
    }
}

public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

public class ValueBasedDiscountFactory : DiscountFactory
{
    private readonly int _value;

    public ValueBasedDiscountFactory(int value)
    {
        _value = value;
    }

    public override DiscountService CreateDiscountService()
    {
        return new ValueBasedDiscountService(_value);
    }
}

public class PercentBasedDiscountFactory : DiscountFactory
{
    private readonly int _value;

    public PercentBasedDiscountFactory(int value)
    {
        _value = value;
    }

    public override DiscountService CreateDiscountService()
    {
        return new PercentBasedDiscountService(_value);
    }
}
