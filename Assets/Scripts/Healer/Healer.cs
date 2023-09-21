using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ChangeHealth(-_heal);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
