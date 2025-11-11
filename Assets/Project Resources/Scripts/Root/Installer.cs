using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [Header("Setting to UI")]
    [SerializeField] private View _view;
    [SerializeField] private Warehouse _warehouse;

    [Header("Setting to CollectItem")]
    [SerializeField] private CollectItem _prefab;
    [SerializeField] private SpawnCollectItem _spawnCollectItem;

    [Header("Setting to Enemy")]
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private List<Transform> _patrollingPoint;

    private Model _model;
    private Controller _controller;

    private void Awake()
    {
        _model = new Model();
        _controller = new Controller(_model);

        _enemyMovement.Initialize(_patrollingPoint.ToList());
        _view.Initialize(_model);
        _warehouse.Initialize(_controller);
        _spawnCollectItem.Initialize(_prefab);
    }
}
