/*
Behavioral pattern.
You have a visitor who has a standard method (Visit) that has different behaviours depending on the tyope of object it visits.
Lets you add a new method to a bunch of different code without having to add new code to them.

Careful: making changes or adding a new element may ask you to change all of the visitors.
*/

public interface IInfrastructure
{
    public void Insure(InsuranceAgent insuranceAgent);
}

public class School : IInfrastructure
{
    public int InitialPrice;
    public int? InsurancePrice;

    public School(int initialPrice)
    {
        InitialPrice = initialPrice;
    }

    public void Insure(InsuranceAgent insuranceAgent)
    {
        insuranceAgent.Visit(this);
        Console.WriteLine($"Our building has been insured for {InsurancePrice} euros.");
    }
}

public class Office : IInfrastructure
{
    public int InitialPrice;
    public int NumberEmployees;
    public int? InsurancePrice;

    public Office(int initialPrice, int numberEmployees)
    {
        InitialPrice = initialPrice;
        NumberEmployees = numberEmployees;
    }

    public void Insure(InsuranceAgent insuranceAgent)
    {
        insuranceAgent.Visit(this);
        Console.WriteLine($"Our building has been insured for {InsurancePrice} euros.");
    }
}

public interface IVisitor
{
    public void Visit(IInfrastructure infrastructure);
}

public class InsuranceAgent : IVisitor
{
    public void Visit(IInfrastructure infrastructure)
    {
        if (infrastructure is Office)
        {
            VisitOffice((Office)infrastructure);
            return;
        }

        if (infrastructure is School)
        {
            VisitSchool((School)infrastructure);
            return;
        }
    }

    private void VisitSchool(School school)
    {
        int insurancePrice = school.InitialPrice / 100;
        school.InsurancePrice = insurancePrice;
    }

    private void VisitOffice(Office office)
    {
        int insurancePrice = office.NumberEmployees * 100;
        office.InsurancePrice = insurancePrice;
    }
}
