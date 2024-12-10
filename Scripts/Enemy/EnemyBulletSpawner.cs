using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : Spawner<Bullet>
{
    [SerializeField] private float _timer;
    [SerializeField] private EnemySpawner _enemySpawner;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _enemySpawner.Spawn += StartShoot;
    }

    private void OnDisable()
    {
        _enemySpawner.Spawn -= StartShoot;
    }

    private void StartShoot()
    {
        _wait = new WaitForSeconds(_timer);
        _coroutine = StartCoroutine(SpawnerTimer());
    }

    private IEnumerator SpawnerTimer()
    {
        while (enabled)
        {
            GetObject();
            yield return _wait;
        }
    }
}