using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private List<Transform> _wayPoints;
    private int _currentWayPoint = 0;

    private void Update()
    {
        Move();
    }

    public void Initialize(List<Transform> wayPoints)
    {
        _wayPoints = wayPoints;
    }

    private void Move()
    {
        if (transform.position.x == _wayPoints[_currentWayPoint].position.x)
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Count;

        Vector2 target = Vector2.one * new Vector2(_wayPoints[_currentWayPoint].position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        Rotate(target.x);
    }

    private void Rotate(float xCoordinateTarget)
    {
        float degreesRotate = 0.0f;

        if (xCoordinateTarget < transform.position.x)
            degreesRotate = 180.0f;

        transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
    }
}
