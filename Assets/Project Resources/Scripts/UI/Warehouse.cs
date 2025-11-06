using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private List<CollectItem> _items;

    private Controller _controller;

    public void Initialize(Controller controller)
    {
        _controller = controller;

        foreach (CollectItem item in _items)
        {
            item.Collected += ChangeView;
        }
    }

    private void ChangeView(CollectItem collectItem)
    {
        collectItem.Collected -= ChangeView;
        _controller.Calculate();
    }
}
