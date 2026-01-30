/*
Tests to verify that our ShallowCopies and DeepCopies work.
*/

using DesignPattern;

namespace DesignPatterns.Test;

public class PrototypeTest
{
    [Fact]
    public void Prototype_ShallowCopy_ReturnsAShallowCopyOfTheObject()
    {
        // Arrange
        Engine engine = new(EngineTypes.Car);
        Car firstCar = new("Audi", 250, engine);

        // Act
        Car secondCar = (Car)firstCar.ShallowCopy();
        firstCar.Engine.EngineType = EngineTypes.Plane;

        // Assert
        Assert.Equal(firstCar.Brand, secondCar.Brand);
        Assert.Equal(firstCar.MaxSpeed, secondCar.MaxSpeed);
        Assert.Equal(firstCar.Engine, secondCar.Engine);
    }

    [Fact]
    public void Prototype_DeepCopy_ReturnsADeepCopyOfTheObject()
    {
        // Arrange
        Engine engine = new(EngineTypes.Car);
        Car firstCar = new("Audi", 250, engine);

        // Act
        Car secondCar = (Car)firstCar.DeepCopy();
        firstCar.Engine.EngineType = EngineTypes.Plane;

        // Assert
        Assert.Equal(firstCar.Brand, secondCar.Brand);
        Assert.Equal(firstCar.MaxSpeed, secondCar.MaxSpeed);
        Assert.NotEqual(firstCar.Engine, secondCar.Engine);
    }
}
