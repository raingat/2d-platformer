using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private TypeTraps _typeTraps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_typeTraps.Damage);
        }
    }
}
