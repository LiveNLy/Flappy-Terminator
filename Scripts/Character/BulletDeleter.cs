using UnityEngine;

public class BulletDeleter : Deleter<Bullet>
{
    protected override void OnTriggerEnter2D(Collider2D collision) { }
}