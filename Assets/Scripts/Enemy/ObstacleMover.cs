using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeBeforeIncreaseSpeed;

    private float _pastTime;

    private void Update()
    {
        _pastTime += Time.deltaTime;
        transform.Translate(Vector2.left * _moveSpeed *  Time.deltaTime);

        if(_pastTime >= _timeBeforeIncreaseSpeed)
        {
            _moveSpeed += 5;
            _pastTime = 0;
        }
    }
}
