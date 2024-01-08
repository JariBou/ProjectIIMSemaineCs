using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private EntityHealth _playerHealth;
    
    // This makes me do some stupid stuff that render the code too complicated for basically nothing
    // private int CachedMaxHealth { get; set; }
    
    private void Start()
    {
        // Maybe we can call the event from EntityHealth script I guess
        // CachedMaxHealth = _playerHealth.CurrentHealth;
    }

    private void UpdateSlider(int newVal, int oldVal)
    {
        _slider.value = newVal / (float)_playerHealth.MaxHealth;
        _text.text = $"{newVal} / {_playerHealth.MaxHealth}";
    }

    private void OnEnable()
    {
        EntityHealth.OnHealthChanged += UpdateSlider;
    }
    
    private void OnDisable()
    {
        EntityHealth.OnHealthChanged -= UpdateSlider;
    }
    
}
