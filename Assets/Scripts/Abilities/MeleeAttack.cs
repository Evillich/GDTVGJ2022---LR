using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LerpAnimator;
using System;

public class MeleeAttack : MonoBehaviour
{
    public enum AttackTypes
    {
        Inexisting = -1,
        LeftSwing = 1,
        RightSwing = 2,
        ForwardSwing = 3,
        BackwardSwing = 4
    }

    public LerpAnimator.LerpAnimator combatAnimator;

    internal void RequestAnimations(List<AttackTypes> orderedAttacks)
    {
        if (orderedAttacks.Count == 0)
            return;

        // we dont support multiorder yet
        combatAnimator.RunAnimationById((int)orderedAttacks[0]);
    }
}
