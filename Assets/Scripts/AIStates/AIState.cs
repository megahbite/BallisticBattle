using ByTheTale.StateMachine;

public abstract class AIState : State
{
   protected IAIStateMachine ai { get { return (IAIStateMachine)machine; } } 
}
