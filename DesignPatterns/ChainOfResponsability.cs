/*
Behavioral pattern. Chain of responsability.
*/

using System.Data.Common;

public enum Role
{
    Manager,
    Senior,
    Junior,
}

public enum Skills
{
    DataScience,
    Programming,
    ScrumMaster,
}

public abstract class AbstractCandidate
{
    public int YearsOfExperience;
    public Role ExpectedRole;
    public List<Skills> AllSkills = new();

    public void AddSkill(Skills skill)
    {
        AllSkills.Add(skill);
    }

    public bool Accepted = true;
}

public class Candidate : AbstractCandidate { }

public interface IHandler<T>
{
    public void Handle(T request);
    public void SetSuccessor(IHandler<T> handler);
}

public class ExperienceEvaluator : IHandler<AbstractCandidate>
{
    private IHandler<AbstractCandidate>? _successor;

    public void Handle(AbstractCandidate request)
    {
        if (request.YearsOfExperience < 3)
        {
            request.Accepted = false;
        }
        if (_successor is not null)
        {
            _successor.Handle(request);
        }
    }

    public void SetSuccessor(IHandler<AbstractCandidate> handler)
    {
        _successor = handler;
    }
}

public class DataScienceSkillEvaluator : IHandler<AbstractCandidate>
{
    private IHandler<AbstractCandidate>? _successor;

    public void Handle(AbstractCandidate request)
    {
        if (!request.AllSkills.Contains(Skills.DataScience))
        {
            request.Accepted = false;
        }
        if (_successor is not null)
        {
            _successor.Handle(request);
        }
    }

    public void SetSuccessor(IHandler<AbstractCandidate> handler)
    {
        _successor = handler;
    }
}
