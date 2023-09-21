using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Shield _shield;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ChangeHealth(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        _shield.Activation();

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
