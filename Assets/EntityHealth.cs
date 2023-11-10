using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] private int _maxHealth;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    private void HealthUpdate(int amount)
    {
        CurrentHealth = Math.Clamp(0, _maxHealth, CurrentHealth+amount);
    }
    
    private void OnEnable()
    {
        PlayerMove.OnHealthUpdate += HealthUpdate;
    }
    
    private void OnDisable()
    {
        PlayerMove.OnHealthUpdate -= HealthUpdate;
    }
}
