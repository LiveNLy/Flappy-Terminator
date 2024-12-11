using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] private Spawner<Bullet> _spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyBulletDeleter bulletDeleter))
        {
            _spawner.ReleaseObject(this);
        }
    }
}