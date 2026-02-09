/*
A script to implement the iterator class
*/

public class Card
{
    public string Value;
    public string Colour;

    public Card(string value, string colour)
    {
        Value = value;
        Colour = colour;
    }
}

public interface ICardIterator
{
    public void AddCard(Card card);
    public Card Next();
    public bool HasNext();
    public bool CheckIfPackIsEmpty();
}

public class PackOfCard : List<Card>
{
    private Random _rng = new();

    public ICardIterator GetIterator()
    {
        return new CardIterator(this);
    }

    public void Shuffle()
    {
        this.OrderBy(_ => _rng.Next()).ToList();
    }
}

// Note: this is not a good implementation, the iteration logic should be separated from the data structure.
public class CardIterator : ICardIterator
{
    private int _cursor = 0;
    private PackOfCard _drawPack;

    public CardIterator(PackOfCard cards)
    {
        _drawPack = cards;
    }

    public void AddCard(Card card)
    {
        _drawPack.Add(card);
    }

    public bool CheckIfPackIsEmpty()
    {
        return _drawPack.Count <= _cursor;
    }

    public Card Next()
    {
        if (_cursor + 1 <= _drawPack.Count)
        {
            _drawPack.Shuffle();
        }
        Card card = _drawPack[_cursor];
        _cursor++;
        return card;
    }

    public bool HasNext()
    {
        return (_cursor + 1 >= _drawPack.Count);
    }
}
