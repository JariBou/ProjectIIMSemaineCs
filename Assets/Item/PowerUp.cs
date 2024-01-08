using System;
using UnityEngine;

public class PowerUp : Item
{
    protected override void Interact(Collider other)
    {
        EntityHealth entityHealth = other.GetComponentInParent<EntityHealth>();
        entityHealth.SetMaxHealth(entityHealth.MaxHealth + _amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact(other);
        }
    }
}
