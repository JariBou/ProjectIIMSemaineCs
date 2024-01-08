using UnityEngine;

public class HealthPotion : Item
{
    protected override void Interact(Collider other)
    {
        EntityHealth entityHealth = other.GetComponentInParent<EntityHealth>();
        entityHealth.AddHealth(_amount);
    }
}
