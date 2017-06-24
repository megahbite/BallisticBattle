using UnityEngine;
using System.Collections;
using ByTheTale.StateMachine;

public abstract class PlayerState : State
{
    protected IPlayerStateMachine player { get { return (IPlayerStateMachine)machine; } }
}
