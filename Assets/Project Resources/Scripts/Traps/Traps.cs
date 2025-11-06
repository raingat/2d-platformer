using System.Collections;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private TypeTraps _typeTraps;
    [SerializeField] private float _attackTime;

    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    private void Awake()
    {
        _delay = new WaitForSeconds(_attackTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Attack(damagable));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable _))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Attack(IDamagable damagable)
    {
        while (enabled)
        {
            damagable.TakeDamage(_typeTraps.Damage);

            yield return _delay;
        }
    }
}
