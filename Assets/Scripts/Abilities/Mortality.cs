using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortality : MonoBehaviour
{
    bool isAlive;
    int maxHealth;
    int currentHealth;

    bool CanAct => isAlive;
}
