using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;

    public event Action<float> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage = 0;

        _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}
