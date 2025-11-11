using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private SpawnCollectItem _spawnCollectItem;

    private Controller _controller;

    private void OnDisable()
    {
        _spawnCollectItem.Spawned -= OnSpawnedItem;
    }

    public void Initialize(Controller controller)
    {
        _controller = controller;
        _spawnCollectItem.Spawned += OnSpawnedItem;
    }

    private void OnSpawnedItem(CollectItem instance)
    {
        instance.Collected += ChangeView;
    }

    private void ChangeView(CollectItem instance)
    {
        instance.Collected -= ChangeView;
        _controller.Calculate();
    }
}
