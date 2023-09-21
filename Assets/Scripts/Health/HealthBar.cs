using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _healthPrefab;

    private List<Health> _healthList = new List<Health>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_healthList.Count < value)
        {
            int addHealth = value - _healthList.Count;

            for (int i = 0; i < addHealth; i++)
            {
                CreateHealth();
            }
        }

        else if (_healthList.Count > value)
        {
            int deleteHealth = _healthList.Count - value;

            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyHealth(_healthList[_healthList.Count - 1]);
            } 
        }
    }

    private void DestroyHealth(Health health)
    {
        _healthList.Remove(health);
        health.ToEmpty();
    }

    private void CreateHealth()
    {
        Health newHealth = Instantiate(_healthPrefab, transform);
        _healthList.Add(newHealth.GetComponent<Health>());
        newHealth.ToFill();
    }
}
