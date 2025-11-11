using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _distance;

    [SerializeField] private Transform _pointRaycast;
    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _raycastHit;

    public bool CanAttack { private set; get; }

    private void FixedUpdate()
    {
        _raycastHit = Physics2D.Raycast(_pointRaycast.position, transform.right, _distance, _layerMask);

        if (_raycastHit.collider != null)
            CanAttack = true;
        else
            CanAttack = false;
    }

    public void Attack()
    {
        if (_raycastHit.transform.TryGetComponent(out IDamagable enemy))
            enemy.TakeDamage(_damage);
    }
}
