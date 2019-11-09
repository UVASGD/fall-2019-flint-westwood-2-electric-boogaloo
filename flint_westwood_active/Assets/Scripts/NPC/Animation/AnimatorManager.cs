using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public static void HandleAnimationChange(Animator animator, AnimationState animationState)
    {
        animator.SetInteger("AnimationState", (int) animationState);
    }
}
