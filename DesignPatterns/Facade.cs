/*
A structural pattern to hide operations behind a facade with which the user can interact.
Make the subsystem easier to use.
*/

public enum AttackType
{
    water,
    fire,
    wind,
    light,
    dark,
}

public class AttackFacade
{
    private int _baseDamage;
    private AttackType _attackType;

    public AttackFacade(int baseDamage, AttackType attackType)
    {
        _baseDamage = baseDamage;
        _attackType = attackType;
    }

    public int Attack(ICharacter target)
    {
        if (CheckIfMiss(target))
        {
            return 0;
        }

        int attackDamage = _baseDamage;
        if (CheckIfTargetIsWeak(target))
        {
            attackDamage *= 2;
        }
        if (IsCriticalHit())
        {
            attackDamage *= 2;
        }

        return attackDamage;
    }

    public bool CheckIfMiss(ICharacter target)
    {
        return false;
    }

    public bool IsCriticalHit()
    {
        return true;
    }

    public bool CheckIfTargetIsWeak(ICharacter target)
    {
        return true;
    }
}

public interface ICharacter { }
