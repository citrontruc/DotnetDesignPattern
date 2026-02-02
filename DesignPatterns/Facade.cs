/*
A structural pattern to hide operations behind a facade with which the user can interact.
Make the subsystem easier to use, we want to abstract the difficulty.
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
    private readonly RNGService _rng = new();
    private readonly ElementalEngine _elemental = new();

    public int ExecuteAttack(int baseDamage, AttackType type, ICharacter target)
    {
        if (_rng.IsMiss())
            return 0;

        int damage = baseDamage;
        if (_elemental.IsWeak(target, type))
            damage *= 2;
        if (_rng.IsCritical())
            damage *= 2;

        return damage;
    }
}

public interface ICharacter { }

public class RNGService
{
    public bool IsCritical() => true;

    public bool IsMiss() => false;
}

public class ElementalEngine
{
    public bool IsWeak(ICharacter target, AttackType type) => true;
}
