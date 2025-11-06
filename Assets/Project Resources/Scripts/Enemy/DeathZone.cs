using System;
using UnityEngine;

public class DeathZone : MonoBehaviour, IPermanentKillable
{
    public event Action Death;

    public void Kill()
    {
        Death?.Invoke();
    }
}
