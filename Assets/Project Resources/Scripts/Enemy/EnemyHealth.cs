using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private DeathZone _deathZone;

    private void OnEnable()
    {
        _deathZone.Death += OnDie;
    }

    private void OnDisable()
    {
        _deathZone.Death -= OnDie;
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }
}
