using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : PlayerUnit
{ 
    List<MeleeAttack.AttackTypes> orderedAttacks = new List<MeleeAttack.AttackTypes>();

    void Update()
    {
        ProcessAttackInput();
        OrderAttacks();
    }

    private void ProcessAttackInput()
    {
        orderedAttacks.Clear();
        if (Input.GetKey(KeyCode.LeftArrow)) orderedAttacks.Add(MeleeAttack.AttackTypes.LeftSwing);
        if (Input.GetKey(KeyCode.RightArrow)) orderedAttacks.Add(MeleeAttack.AttackTypes.RightSwing);
        if (Input.GetKey(KeyCode.UpArrow)) orderedAttacks.Add(MeleeAttack.AttackTypes.ForwardSwing);
        if (Input.GetKey(KeyCode.DownArrow)) orderedAttacks.Add(MeleeAttack.AttackTypes.BackwardSwing);
    }

    private void OrderAttacks()
    {
        if (!controlledUnit)
            return;

        var attack = controlledUnit.GetComponent<MeleeAttack>();
        attack.RequestAnimations(orderedAttacks);
    }
}
