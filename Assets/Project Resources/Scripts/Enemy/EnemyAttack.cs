using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _waitTimeToAttack;

    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    private void Awake()
    {
        _delay = new WaitForSeconds(_waitTimeToAttack);
    }

    private void FixedUpdate()
    {
        if (_weapon.CanAttack)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(AttackTarget());
            }
        }

        if (_weapon.CanAttack == false)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);

                _coroutine = null;
            }
        }
    }

    private IEnumerator AttackTarget()
    {
        while (enabled)
        {
            _weapon.Attack();

            yield return _delay;
        }
    }
}
