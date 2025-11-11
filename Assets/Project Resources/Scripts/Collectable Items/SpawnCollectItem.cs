using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectItem : MonoBehaviour
{
    [SerializeField] private int _startCount;
    [SerializeField] private List<Transform> _places;

    private PoolCollectItem _pool;

    public event Action<CollectItem> Spawned;

    public void Initialize(CollectItem prefab)
    {
        _pool = new PoolCollectItem(prefab);
        CreateStartCount();
    }

    private void CreateStartCount()
    {
        for (int i = 0; i < _startCount; i++)
        {
            CollectItem instance = _pool.Get();
            instance.transform.position = _places[i].transform.position;

            instance.Collected += OnReturnToPool;
            Spawned?.Invoke(instance);
        }
    }

    private void OnReturnToPool(CollectItem instance)
    {
        instance.Collected -= OnReturnToPool;
        _pool.Release(instance);
    }
}
