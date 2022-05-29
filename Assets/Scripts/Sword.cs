using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword : MonoBehaviour
{
    public MeleeAttack meleeAttack;
    public int damage = 1;
    [SerializeField] private List<Mortality> hitEnemies;

    private void Awake()
    {
        meleeAttack.OnAttack += () => hitEnemies.Clear();
        Collider[] colliders = meleeAttack.GetComponents<Collider>();
        Collider collider = GetComponent<Collider>();
        foreach (var coll in colliders)
        {
            Physics.IgnoreCollision(collider, coll);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision from " + this);

        var mortality = collision.gameObject.GetComponent<Mortality>();
        if (mortality == null)
            return;

        if (hitEnemies.Contains(mortality))
            return;

        hitEnemies.Add(mortality);

        mortality.TakeHit(damage);
    }
}
