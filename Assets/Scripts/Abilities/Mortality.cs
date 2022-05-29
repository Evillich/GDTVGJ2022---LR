using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortality : MonoBehaviour
{
    bool isAlive;
    int maxHealth = 10;
    int currentHealth;

    bool CanAct => isAlive;

    public System.Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
            return;

        isAlive = false;
        OnDeath?.Invoke();
    }
}
