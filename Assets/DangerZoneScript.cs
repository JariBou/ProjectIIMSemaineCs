using System;
using Codice.Client.BaseCommands;
using UnityEngine;

public class DangerZoneScript : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private float _interactionDelay;

    private float _timer;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _timer = _interactionDelay;
        
        other.GetComponentInParent<EntityHealth>().AddHealth(-_damageAmount);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _timer -= Time.fixedDeltaTime;
        if (_timer <= 0)
        {
            other.GetComponentInParent<EntityHealth>().AddHealth(-_damageAmount);
            _timer = _interactionDelay;
        }
    }

    private void OnValidate()
    {
        if (_damageAmount < 0)
        {
            _damageAmount = -_damageAmount;
        }
        
        if (_interactionDelay < 0)
        {
            _interactionDelay = -_interactionDelay;
        }
    }
}
