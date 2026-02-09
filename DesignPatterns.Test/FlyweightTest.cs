using Flyweight;

namespace DesignPatterns.Test;

public class FlyweightTest
{
    [Fact]
    public void Flyweight_isAskedToCreateMultipleInstancesOfTexture_ReturnsSameTexture()
    {
        // Arrange
        Dictionary<EnemyTypes, string> enemyTextureDirectory = new()
        {
            { EnemyTypes.Bat, "" },
            { EnemyTypes.Zombie, "" },
        };

        EnnemyFactory ennemyFactory = new(enemyTextureDirectory);

        // Act
        Ennemy firstEnnemy = ennemyFactory.CreateEnnemy(0, 0, EnemyTypes.Bat);
        Ennemy secondEnnemy = ennemyFactory.CreateEnnemy(0, 0, EnemyTypes.Bat);

        // Assert
        Assert.Equal(firstEnnemy.GetTexture(), secondEnnemy.GetTexture());
    }
}
