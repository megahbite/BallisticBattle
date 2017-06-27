using ByTheTale.StateMachine;

/// <summary>
/// Convenience abstract class so our states can chat to the state machine easier
/// </summary>
public abstract class AIState : State
{
   protected IAIStateMachine ai { get { return (IAIStateMachine)machine; } } 
}
