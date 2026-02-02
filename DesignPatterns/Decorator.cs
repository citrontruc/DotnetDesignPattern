/*
Wrap around a class in order to add additional functionalities.
*/

namespace DesignPattern;

public interface ICoffee
{
    public bool Drink(int volumeToDrink);
    public string GetSmell();
}

public class Coffee : ICoffee
{
    private int _volume;

    public Coffee(int volume)
    {
        _volume = volume;
    }

    public bool Drink(int volumeToDrink)
    {
        if (_volume >= volumeToDrink)
        {
            _volume -= volumeToDrink;
            return true;
        }
        return false;
    }

    public string GetSmell()
    {
        return "The fragrance of black coffee";
    }
}

public abstract class CoffeeDecoratorBase : ICoffee
{
    private ICoffee _coffee;

    public CoffeeDecoratorBase(Coffee coffee)
    {
        _coffee = coffee;
    }

    public bool Drink(int volumeToDrink)
    {
        return _coffee.Drink(volumeToDrink);
    }

    public virtual string GetSmell()
    {
        return _coffee.GetSmell();
    }
}

public class CoffeeWithCinnaon : CoffeeDecoratorBase
{
    public CoffeeWithCinnaon(Coffee coffee)
        : base(coffee) { }

    public override string GetSmell()
    {
        return $"{base.GetSmell()} with a touch of cinnamon";
    }
}
