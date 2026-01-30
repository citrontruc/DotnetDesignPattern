/*
Essentially, it lets you create objects can copy themselves.
Shallow copies copy all the value type elements but share the reference types elements.
Imagine I have an object with an int property and a list property.
If I do a shallow copy and modify the int, it will be modified for one of the instances but if I modify the list, it will be modified for both instances.
*/
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace DesignPattern;

public interface VehiclePrototype
{
    public VehiclePrototype ShallowCopy();

    // The simplest way to have a deepcopy is to create a new instance of the class and copy propertywise the values.
    public VehiclePrototype DeepCopy();
}

public class Airplane : VehiclePrototype
{
    public string Brand;

    public Airplane(string brandName)
    {
        Brand = brandName;
    }

    public VehiclePrototype ShallowCopy()
    {
        // Method possessed by every object.
        return (VehiclePrototype)MemberwiseClone();
    }

    public VehiclePrototype DeepCopy()
    {
        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        var objectAsJson = JsonConvert.SerializeObject(this, typeof(Airplane), settings);
        return JsonConvert.DeserializeObject<VehiclePrototype>(objectAsJson, settings);
    }
}

public class Car : VehiclePrototype
{
    public string Brand;
    public int MaxSpeed;

    public Car(string brandName, int maxSpeed)
    {
        Brand = brandName;
        MaxSpeed = maxSpeed;
    }

    public VehiclePrototype ShallowCopy()
    {
        // Method possessed by every object.
        return (VehiclePrototype)MemberwiseClone();
    }

    public VehiclePrototype DeepCopy()
    {
        Car newCar = new(Brand, MaxSpeed);
        return newCar;
    }
}
