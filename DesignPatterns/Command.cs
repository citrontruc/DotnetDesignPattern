/*
Command design pattern: has an object that lets you give orders to other objects.
*/

public class Lamp
{
    public void TurnOn() => Console.WriteLine("Lights on");

    public void TurnOff() => Console.WriteLine("Lights off");
}

public interface ICommand
{
    void Execute();
}

/// <summary>
/// The Command should know to who it sends the command.
/// </summary>
public class SwitchOnCommand : ICommand
{
    private readonly Lamp _lamp;

    public SwitchOnCommand(Lamp lamp) => _lamp = lamp;

    public void Execute() => _lamp.TurnOn();
}

public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command) => _command = command;

    public void PressButton() => _command.Execute();
}

/*
public interface ICommand
{
    public bool CanExecute(ElectricDevice electricDevice);
    public void Execute(ElectricDevice electricDevice);
}

public class SwitchOnCommand : ICommand
{
    public bool CanExecute(ElectricDevice electricDevice) { return true; }
    public void Execute(ElectricDevice electricDevice)
    {
        electricDevice.SwitchOn();
    }
}

public class SwitchOffCommand : ICommand
{
    private ElectricDevice _electriDevice = new EmptySocket();

    public bool CanExecute(ElectricDevice electricDevice) { return true; }
    public void Execute(ElectricDevice electricDevice)
    {
        electricDevice.SwitchOff();
    }
}

public interface ElectricDevice
{
    public void SwitchOn();
    public void SwitchOff();
}

public class Lamp : ElectricDevice
{
    public void SwitchOn()
    {
        Console.WriteLine("The room is filled with lights");
    }

    public void SwitchOff()
    {
        Console.WriteLine("The room goes dark");
    }
}

public class TVSet : ElectricDevice
{
    public void SwitchOn()
    {
        Console.WriteLine("You can now watch the TV.");
    }

    public void SwitchOff()
    {
        Console.WriteLine("The TV goes blank");
    }
}

public class EmptySocket : ElectricDevice
{
    public bool CanExecute() { return true; }
    public void SwitchOn() { }

    public void SwitchOff() { }
}

public class ElectricSocket
{
    private ElectricDevice _electriDevice = new EmptySocket();
    public SwitchOnCommand switchOnCommand = new();
    public SwitchOnCommand switchOffCommand = new();

    public void Plug(ElectricDevice electricDevice)
    {
        if (switchOffCommand.CanExecute(_electriDevice))
        {
            switchOffCommand.Execute(_electriDevice);
        }
        _electriDevice = electricDevice;
        if (switchOnCommand.CanExecute(_electriDevice))
        {
            switchOnCommand.Execute(_electriDevice);
        }
    }
}
*/
