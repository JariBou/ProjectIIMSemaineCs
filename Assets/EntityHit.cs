using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHit : MonoBehaviour
{
    [SerializeField] private int _damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.AddHealth(-_damageAmount);
        }
    }
}
