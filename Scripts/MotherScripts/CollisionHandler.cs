using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action GettingHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDanger danger))
        {
            GettingHit?.Invoke();
        }
    }
}