using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded()
    {
        Collider2D findCollider = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);

        if (findCollider != null && findCollider.TryGetComponent(out TilemapCollider2D _))
            return true;
        else
            return false;
    }
}
