/*
Behavioral pattern.
Allows to change behaviour depending on our state.
*/

public abstract class AsbtractGuard
{
    public AbstractGuardState GuardState { get; set; }
    public abstract void Update(decimal dt);

    public AsbtractGuard()
    {
        GuardState = new WaitState(this);
    }
}

public class Guard : AsbtractGuard
{
    public Guard()
        : base() { }

    public override void Update(decimal dt)
    {
        GuardState.Update(dt);
    }
}

// States

public abstract class AbstractGuardState
{
    protected AsbtractGuard _guard;

    public AbstractGuardState(AsbtractGuard guard)
    {
        _guard = guard;
    }

    public abstract void Update(decimal dt);

    public void TransitionToState(AbstractGuardState state)
    {
        _guard.GuardState = state;
    }
}

public class SleepState : AbstractGuardState
{
    private decimal _sleepClock = 0;

    public SleepState(AsbtractGuard guard)
        : base(guard) { }

    public override void Update(decimal dt)
    {
        _sleepClock += dt;
        if (_sleepClock > 10)
        {
            Console.WriteLine("I'm all rested");
            TransitionToState(new PatrolState(_guard));
        }
    }
}

public class PatrolState : AbstractGuardState
{
    private decimal _patrolClock = 0;

    public PatrolState(AsbtractGuard guard)
        : base(guard) { }

    public override void Update(decimal dt)
    {
        _patrolClock += dt;
        if (_patrolClock > 2)
        {
            Console.WriteLine("I'm tired of patrolling");
            TransitionToState(new WaitState(_guard));
        }
    }
}

public class WaitState : AbstractGuardState
{
    private decimal _waitClock = 0;

    public WaitState(AsbtractGuard guard)
        : base(guard) { }

    public override void Update(decimal dt)
    {
        _waitClock += dt;
        if (_waitClock > 2)
        {
            Console.WriteLine("I'm getting tired");
            TransitionToState(new SleepState(_guard));
        }
    }
}
