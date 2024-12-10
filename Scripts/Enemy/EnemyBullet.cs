using UnityEngine;

public class EnemyBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyBulletDeleter bulletDeleter))
        {
            _spawner.ReleaseObject(this);
        }
    }
}
