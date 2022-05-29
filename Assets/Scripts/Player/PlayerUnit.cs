using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Player
{
    [SerializeField] protected Unit controlledUnit;
    public System.Action<Unit> OnControlledUnitChange;
    public Unit ControlledUnit { set { controlledUnit = value; OnControlledUnitChange?.Invoke(controlledUnit); } }
}
