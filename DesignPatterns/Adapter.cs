/*
Adapter pattern is a structural pattern.
Risk is of information being lost.
*/

/// <summary>
/// Using classes is with the IBook interface is maybe the best way to do things.
/// </summary>
public struct Book
{
    public string Name;
    public string Author;
    public int NumPages;
}

public struct Comics
{
    public string Name;
    public string Writer;
    public string Drawer;
    public int NumPages;
}

public interface IComicsToBooksAdapter
{
    public Book GetAsBook();
}

public class ComicsToBookAdapter : IComicsToBooksAdapter
{
    private Comics _comic;

    public ComicsToBookAdapter(Comics comic)
    {
        _comic = comic;
    }

    public Book GetAsBook()
    {
        return new Book()
        {
            Name = _comic.Name,
            Author = $"Writer {_comic.Writer} - Drawer {_comic.Drawer}",
            NumPages = _comic.NumPages,
        };
    }
}

// ---
// Version with classes.

public interface INovel { }

public class Manga
{
    public string Name;
    public string Writer;
    public string Drawer;
    public int NumPages;

    public Manga(string name, string writer, string drawer, int numPages)
    {
        Name = name;
        Writer = writer;
        Drawer = drawer;
        NumPages = numPages;
    }
}

public class MangaToBookAdapter : INovel
{
    private readonly Manga _manga;

    public MangaToBookAdapter(Manga manga) => _manga = manga;

    public string Name => _manga.Name;
    public string Author => $"Writer: {_manga.Writer}, Drawer: {_manga.Drawer}";
    public int NumPages => _manga.NumPages;
}
