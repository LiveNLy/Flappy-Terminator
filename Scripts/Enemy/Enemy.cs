using UnityEngine;

public class Enemy : Prefab
{
    [SerializeField] private GameMenuController _game;
    [SerializeField] protected Spawner<Enemy> _spawner;

    private void OnEnable()
    {
        _game.RestartGame += Restart;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterBullet bullet))
        {
            _spawner.ReleaseObject(this);
        }
    }

    private void OnDisable()
    {
        _game.RestartGame -= Restart;
    }

    private void Restart()
    {
        _spawner.ReleaseObject(this);
    }
}