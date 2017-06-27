using UnityEngine;

/// <summary>
/// Once the animation is done, destroy the object.
/// </summary>
public class ExplosionBehaviour : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
