/*
Flyweight: does not require object identity, for objects with a big number of elements that need to be mutualized because we have limited memory / process time.
*/

namespace Flyweight;

public enum EnemyTypes
{
    Bat,
    Zombie,
}

public class Texture
{
    public int SizeX;
    public int SizeY;
}

public interface ITextureObject
{
    public (int, int) GetSize();
    public Texture? GetTexture();
    protected void LoadTexture(string textureDirectory);
    public void Draw(int x, int y);
}

public class TextureWrapper : ITextureObject
{
    private Texture? _texture;

    public TextureWrapper() { }

    public TextureWrapper(string textureDirectory)
    {
        LoadTexture(textureDirectory);
    }

    public TextureWrapper(Texture texture)
    {
        _texture = texture;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing texture in position {x}, {y}.");
    }

    public (int, int) GetSize()
    {
        if (_texture is null)
        {
            return (0, 0);
        }
        return (_texture.SizeX, _texture.SizeY);
    }

    public Texture? GetTexture()
    {
        return _texture;
    }

    public void LoadTexture(string textureDirectory)
    {
        Console.WriteLine($"Loading texture saved at {textureDirectory}.");
    }
}

public class Ennemy
{
    public int PositionX;
    public int PositionY;
    public ITextureObject Texture;

    public Ennemy(int x, int y, ITextureObject texture)
    {
        PositionX = x;
        PositionY = y;
        Texture = texture;
    }

    public ITextureObject GetTexture()
    {
        return Texture;
    }

    public void Draw()
    {
        Texture.Draw(PositionX, PositionY);
    }
}

public class EnnemyFactory
{
    private Dictionary<EnemyTypes, string> _ennemyTextureDirectory;
    private Dictionary<EnemyTypes, ITextureObject> _ennemyTypeTextures = new();

    public EnnemyFactory(Dictionary<EnemyTypes, string> enemyTextureDirectory)
    {
        _ennemyTextureDirectory = enemyTextureDirectory;
    }

    public Ennemy CreateEnnemy(int positionX, int positionY, EnemyTypes enemyTypes)
    {
        if (!_ennemyTypeTextures.ContainsKey(enemyTypes))
        {
            TextureWrapper textureWrapper = new(_ennemyTextureDirectory[enemyTypes]);
            _ennemyTypeTextures[enemyTypes] = textureWrapper;
        }
        return new Ennemy(positionX, positionY, _ennemyTypeTextures[enemyTypes]);
    }
}
