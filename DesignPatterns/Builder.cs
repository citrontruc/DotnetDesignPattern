/*
A script to implement he builder pattern.
Let's us create elements step by step.
Let's us separate the creation of object from the object.
*/

namespace DesignPattern;

public class AsusPCBuilder : PCBuilder
{
    public AsusPCBuilder()
        : base("Asus") { }

    public override void BuildMotherBoard()
    {
        Pc.PCMotherBoard = new AsusMotherBoard();
    }

    public override void BuildCPU()
    {
        Pc.PCCPU = new AsusCpu();
    }

    public override void BuildCoolingSystem()
    {
        Pc.CoolingSystem = new AsusCoolingSystem();
    }
}

public abstract class PCBuilder
{
    public PC Pc { get; private set; }

    public PCBuilder(string brandName)
    {
        Pc = new PC(brandName);
    }

    public abstract void BuildMotherBoard();
    public abstract void BuildCPU();
    public abstract void BuildCoolingSystem();
}

public class PC
{
    public IMotherBoard? PCMotherBoard;
    public ICPU? PCCPU;
    public ICoolingSystem? CoolingSystem;
    private string _brandName;

    public PC(string brandName)
    {
        _brandName = brandName;
    }
}

public interface IMotherBoard { }

public class AsusMotherBoard : IMotherBoard { }

public interface ICPU { }

public class AsusCpu : ICPU { }

public interface ICoolingSystem { }

public class AsusCoolingSystem : ICoolingSystem { }
