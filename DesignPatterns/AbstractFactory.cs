/*
A class to create abstract factories.
Abstract factories create a family of objects (when family needs to be created together).
*/

namespace DesignPattern;

public class DarkWebsiteFactor : IWebsiteAbstractFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public IWindow CreateWindow()
    {
        return new DarkWindow();
    }
}

public class LightWebsiteFactor : IWebsiteAbstractFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public IWindow CreateWindow()
    {
        return new LightWindow();
    }
}

public interface IWebsiteAbstractFactory
{
    public IButton CreateButton();
    public IWindow CreateWindow();
}

public interface IButton
{
    public string Press();
}

public interface IWindow
{
    public string Render();
}

public class DarkButton : IButton
{
    public string Press()
    {
        return "You pressed a dark button";
    }
}

public class LightButton : IButton
{
    public string Press()
    {
        return "You pressed a light button";
    }
}

public class DarkWindow : IWindow
{
    public string Render()
    {
        return "You are viewing a dark window";
    }
}

public class LightWindow : IWindow
{
    public string Render()
    {
        return "You are viewing a light window";
    }
}
