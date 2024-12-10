using System;
using UnityEngine;

public class EnemyCollisionHandler : CollisionHandler
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BackgroundDeleter deleter))
        {
            _spawner.ReleaseObject(_enemy);
        }
    }
}