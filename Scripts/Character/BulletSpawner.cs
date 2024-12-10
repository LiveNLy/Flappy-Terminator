using UnityEngine;

public class BulletSpawner :Spawner<Bullet>
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.Shooted += GetObject;
    }

    private void OnDisable()
    {
        _inputReader.Shooted -= GetObject;
    }
}