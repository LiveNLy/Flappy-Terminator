using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : Prefab 
{
    [SerializeField] private GameMenuController _game;
    [SerializeField] protected Spawner<Bullet> _spawner;

    private void OnEnable()
    {
        _game.RestartGame += Restart;
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