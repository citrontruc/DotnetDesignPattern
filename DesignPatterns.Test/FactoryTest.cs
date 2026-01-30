/*
Test to evaluate the behaviour of The factory pattern.
*/

using DesignPattern;

namespace DesignPatterns.Test;

public class FactoryTest
{
    [Fact]
    public void Factory_CreatesExpectedDiscountService_ValueDiscount()
    {
        // Arrange
        int valuePrice = 10;
        int valueDiscount = 10;
        IDiscountFactory discountFactory = new ValueBasedDiscountFactory(valueDiscount);
        IDiscountService discountService = discountFactory.CreateDiscountService();

        // Act
        int valueAfterDiscount = discountService.ApplyDiscount(valuePrice);

        // Assert
        Assert.Equal(Math.Max(0, valuePrice - valueDiscount), valueAfterDiscount);
    }

    [Fact]
    public void Factory_CreatesExpectedDiscountService_PercentageDiscount()
    {
        // Arrange
        int valuePrice = 10;
        int valueDiscount = 10;
        IDiscountFactory discountFactory = new PercentBasedDiscountFactory(valueDiscount);
        IDiscountService discountService = discountFactory.CreateDiscountService();

        // Act
        int valueAfterDiscount = discountService.ApplyDiscount(valuePrice);

        // Assert
        Assert.Equal(valuePrice * ((100 - valueDiscount) / 100), valueAfterDiscount);
    }
}
