using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private Warehouse _warehouse;

    private Model _model;
    private Controller _controller;

    private void Awake()
    {
        _model = new Model();
        _controller = new Controller(_model);
        _view.Initialize(_model);
        _warehouse.Initialize(_controller);
    }
}
