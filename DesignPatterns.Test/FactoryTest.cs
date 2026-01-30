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
        DiscountFactory discountFactory = new ValueBasedDiscountFactory(valueDiscount);
        DiscountService discountService = discountFactory.CreateDiscountService();

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
        DiscountFactory discountFactory = new PercentBasedDiscountFactory(valueDiscount);
        DiscountService discountService = discountFactory.CreateDiscountService();

        // Act
        int valueAfterDiscount = discountService.ApplyDiscount(valuePrice);

        // Assert
        Assert.Equal(valuePrice * ((100 - valueDiscount) / 100), valueAfterDiscount);
    }
}
