using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorGenerator : MonoBehaviour
{
    public Motion idleMotion;
    public Motion movingMotion;
    public Motion attackingMotion;
    public Motion dyingMotion;
    public Motion specialMotion;


    void Start()
    {
        AddControllerTransitions((AnimatorController) this.GetComponent<Animator>().runtimeAnimatorController);
    }
    
    void AddControllerTransitions(AnimatorController controller)
    {
        var rootStateMachine = controller.layers[0].stateMachine;
        
        var idleState = rootStateMachine.AddState("Idle");
        var movingState = rootStateMachine.AddState("Moving");
        var attackingState = rootStateMachine.AddState("Attacking");
        var dyingState = rootStateMachine.AddState("Dying");
        var specialState = rootStateMachine.AddState("Special");
        idleState.motion = idleMotion;
        movingState.motion = movingMotion;
        attackingState.motion = attackingMotion;
        dyingState.motion = dyingMotion;
        specialState.motion = specialMotion;
        


        rootStateMachine.defaultState = idleState;
        var idleToMovingTransition = idleState.AddTransition(movingState);
        var movingToIdleTransition = movingState.AddTransition(idleState);
        idleToMovingTransition.AddCondition(AnimatorConditionMode.If, 1, "AnimationState");
        movingToIdleTransition.AddCondition(AnimatorConditionMode.If, 0, "AnimationState");

        var movingToAttackingTransition = movingState.AddTransition(attackingState);
        var attackingToMovingTransition = attackingState.AddTransition(movingState);
        movingToAttackingTransition.AddCondition(AnimatorConditionMode.If, 2, "AnimationState");
        attackingToMovingTransition.AddCondition(AnimatorConditionMode.If, 1, "AnimationState");
    }

    AnimatorStateTransition AddTransition(AnimatorState fromState, AnimatorState toState, int stateValue=0)
    {
        AnimatorStateTransition newTransition = fromState.AddTransition(toState);
        AddCondition(newTransition, stateValue);
        return newTransition;
    }

    void AddCondition(AnimatorStateTransition transition, int stateValue)
    {
        transition.AddCondition(AnimatorConditionMode.If, stateValue, "AnimationState");
    }
}
