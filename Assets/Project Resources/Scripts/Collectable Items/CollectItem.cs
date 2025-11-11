using System;
using UnityEngine;

public class CollectItem : MonoBehaviour, ICollectable
{
    public event Action<CollectItem> Collected;

    public void Collect()
    {
        Activate();
    }

    private void Activate()
    {
        Collected?.Invoke(this);
    }
}
