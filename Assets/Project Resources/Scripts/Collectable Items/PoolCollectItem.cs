using System.Collections.Generic;
using UnityEngine;

public class PoolCollectItem
{
    private CollectItem _prefab;

    private Queue<CollectItem> _pool = new();

    public PoolCollectItem(CollectItem prefab)
    {
        _prefab = prefab;
    }

    public CollectItem Get()
    {
        if (_pool.Count == 0)
            Expand();

        CollectItem instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void Release(CollectItem instance)
    {
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
    }

    private void Expand()
    {
        CollectItem instance = GameObject.Instantiate(_prefab);
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
    }
}
