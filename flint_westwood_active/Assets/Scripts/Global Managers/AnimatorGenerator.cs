using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatorGenerator : MonoBehaviour
{
    [MenuItem("Animators/Create New Controller")]
    static void CreateController()
    {
        // Creates the controller
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Mecanim/StateMachineTransitions.controller");

        // Add parameters
        controller.AddParameter("AnimationState", AnimatorControllerParameterType.Int);

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        // Add States
        var idleState = rootStateMachine.AddState("Idle");
        var movingState = rootStateMachine.AddState("Moving");
        var attackingState = rootStateMachine.AddState("Attacking");
        var dyingState = rootStateMachine.AddState("Dying");
        var specialState = rootStateMachine.AddState("Special");

        // Add Transitions
//        var exitTransition = stateA1.AddExitTransition();
//        exitTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "TransitionNow");
//        exitTransition.duration = 0;
//
//        var resetTransition = rootStateMachine.AddAnyStateTransition(stateA1);
//        resetTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "Reset");
//        resetTransition.duration = 0;



        rootStateMachine.defaultState = idleState;
        var idleToMovingTransition = idleState.AddTransition(movingState);
        var movingToIdleTransition = movingState.AddTransition(idleState);
        idleToMovingTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 1, "AnimationState");
        movingToIdleTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "AnimationState");

        var movingToAttackingTransition = movingState.AddTransition(attackingState);
        var attackingToMovingTransition = attackingState.AddTransition(movingState);
        
    }
}
