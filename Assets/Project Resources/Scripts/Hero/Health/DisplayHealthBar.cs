using UnityEngine;

public class DisplayHealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _point;

    private void Update()
    {
        _canvas.transform.position = _point.position;
    }
}
