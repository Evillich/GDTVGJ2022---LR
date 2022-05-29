using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSetter : MonoBehaviour
{
    [SerializeField] List<PlayerUnit> players;
    [SerializeField] UnitProcessor units;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            foreach (var player in players)
            {
                player.ControlledUnit = units.GetNextUnit();
            }


        if (Input.GetKeyDown(KeyCode.R))
            foreach (var player in players)
            {
                player.ControlledUnit = units.GetRandomUnit();
            }
    }
}
