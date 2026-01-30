/*
A class to implement the singleton pattern. We are using a logger in this case.
Creational pattern.
*/

namespace DesignPattern;

public sealed class Singleton
{
    private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
    public static Singleton Instance => _instance.Value;

    private Singleton() { }
}

public sealed class SingletonNotThreadSafe
{
    private static SingletonNotThreadSafe? _instance;
    public static SingletonNotThreadSafe Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new SingletonNotThreadSafe();
            }
            return _instance;
        }
    }

    private SingletonNotThreadSafe() { }
}
