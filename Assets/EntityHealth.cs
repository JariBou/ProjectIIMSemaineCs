using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] private int _maxHealth;

    public static event Action<int, int> OnHealthChanged; // int newVal, int oldVal
    public static event Action<int> OnMaxHealthChanged;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        OnHealthChanged?.Invoke(CurrentHealth, 0);
        OnMaxHealthChanged?.Invoke(_maxHealth);
    }

    public void AddHealth(int amount)
    {
        int oldVal = CurrentHealth;
        CurrentHealth = Math.Clamp( CurrentHealth+amount, 0, _maxHealth);
        OnHealthChanged?.Invoke(CurrentHealth, oldVal);
    }

    public void SetMaxHealth(int amount)
    {
        int delta = amount - _maxHealth;
        _maxHealth = amount;
        AddHealth(delta);
        OnMaxHealthChanged?.Invoke(_maxHealth);
    }

}
