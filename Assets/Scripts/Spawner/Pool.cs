using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _containerCapacity;

    private int _healersCount;
    private List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        _healersCount = _containerCapacity / 5;
    }

    private GameObject InstantiateObject(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.gameObject.SetActive(false);

        return spawned;
    }

    protected void Initialize(GameObject prefab, GameObject healers)
    {
        for (int i = 0; i < _containerCapacity; i++)
        {
            if (i < _containerCapacity - _healersCount)
            {
                _pool.Add(InstantiateObject(prefab));
            }
            else
            {
                _pool.Add(InstantiateObject(healers));
            }
        }
    }

    protected bool TryGetEnemy(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false && p.TryGetComponent<Enemy>(out Enemy enemy) == true);

        return result != null;
    }

    protected bool TryGetHealer(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false && p.TryGetComponent<Healer>(out Healer healer) == true);

        return result != null;
    }
}