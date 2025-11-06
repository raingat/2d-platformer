using UnityEngine;

[CreateAssetMenu(fileName = "New Traps", order = 51)]
public class TypeTraps : ScriptableObject
{
    [SerializeField] private float _damage;

    public float Damage => _damage;
}
