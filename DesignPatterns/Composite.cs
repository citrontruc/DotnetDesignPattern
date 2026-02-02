/*
A structural pattern to compose for items in a tree structure.
Leaf elements must implement the same interface as container elements. ==> Must keep interface simple.
*/

public interface IProduct
{
    public int GetPrice();
}

public class Product : IProduct
{
    private int _price;

    public Product(int price)
    {
        _price = price;
    }

    public int GetPrice()
    {
        return _price;
    }
}

public class ShoppingCart : IProduct
{
    private List<IProduct> _allProducts = new();

    public void AddProductToCart(IProduct product)
    {
        _allProducts.Add(product);
    }

    public bool RemoveProductFromCart(IProduct product)
    {
        return _allProducts.Remove(product);
    }

    public int GetPrice()
    {
        return _allProducts.Aggregate(0, (a, b) => a + b.GetPrice());
    }
}
