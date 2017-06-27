using ByTheTale.StateMachine;

/// <summary>
/// Convenience abstract class so our states can chat to the state machine easier
/// </summary>
public abstract class PlayerState : State
{
    protected IPlayerStateMachine player { get { return (IPlayerStateMachine)machine; } }
}
