using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _layerMask;

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _distance, _layerMask);

        if (hit.collider != null && hit.transform.TryGetComponent(out TilemapCollider2D _))
            return true;
        else
            return false;
    }
}
