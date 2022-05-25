using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSetter : MonoBehaviour
{
    [SerializeField] PlayerUnit player;
    [SerializeField] UnitProcessor units;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            player.ControlledUnit = units.GetNextUnit();

        if (Input.GetKeyDown(KeyCode.R))
            player.ControlledUnit = units.GetRandomUnit();


    }
}
