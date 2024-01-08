using UnityEngine;

public class Gold : Item
{
    protected override void Interact(Collider other)
    {
        other.GetComponentInParent<EntityGold>().AddGold(_amount);
    }
}
