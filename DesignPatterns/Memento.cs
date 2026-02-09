/*
A script to implement the Memento design pattern.
*/

public interface IBankAccount
{
    public void CreditAccount(int sum);
    public bool DebitAccount(int sum);
}

/// <summary>
/// Not necessary, the bank can handle its own account.
/// Can be simpler to separate concerns.
/// </summary>
public class BankAccountManager
{
    private BankAccount _bankAccount;
    private Caretaker _caretaker;

    public BankAccountManager(int initialValue)
    {
        _bankAccount = new(initialValue);
        _caretaker = new(_bankAccount);
    }

    public void CreditAccount(int sum)
    {
        _caretaker.CreateMemento();
        _bankAccount.CreditAccount(sum);
    }

    public bool DebitAccount(int sum)
    {
        _caretaker.CreateMemento();
        return _bankAccount.DebitAccount(sum);
    }

    public void Undo()
    {
        _caretaker.Undo();
    }
}

public class BankAccount : IBankAccount
{
    public int AccountValue;

    public BankAccount(int initialValue)
    {
        AccountValue = initialValue;
    }

    public void CreditAccount(int sum)
    {
        AccountValue += sum;
    }

    public bool DebitAccount(int sum)
    {
        if (AccountValue < sum)
        {
            return false;
        }
        AccountValue -= sum;
        return true;
    }
}

public interface IMemento { }

public class BankMementos : IMemento
{
    public int AccountValue;

    public BankMementos(int accountValue)
    {
        AccountValue = accountValue;
    }
}

public class Caretaker
{
    private Stack<BankMementos> _bankMementos = new();
    private BankAccount _bankAccount;

    public Caretaker(BankAccount bankAccount)
    {
        _bankAccount = bankAccount;
    }

    public void CreateMemento()
    {
        _bankMementos.Push(new BankMementos(_bankAccount.AccountValue));
    }

    public void RestoreMemento(BankMementos bankMementos)
    {
        _bankAccount.AccountValue = bankMementos.AccountValue;
    }

    public void Undo()
    {
        if (_bankMementos.Any())
        {
            BankMementos bankMemento = _bankMementos.Pop();
            RestoreMemento(bankMemento);
        }
    }
}
