using System;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _timer;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    public event Action Spawn;

    private void Start()
    {
        _wait = new WaitForSeconds(_timer);
        _coroutine = StartCoroutine(SpawnerTimer());
    }

    protected override void SetObject(ObjectMover prefab)
    {
        prefab.transform.position = SetPosition();
        prefab.gameObject.SetActive(true);
    }

    protected Vector3 SetPosition()
    {
        Vector3 position = _spawnPoints[0].transform.position;
        float minRandom = -4f;
        float maxRandom = 4f;

        position.y = position.y - Random.Range(minRandom, maxRandom);

        return position;
    }

    private IEnumerator SpawnerTimer()
    {
        while (enabled)
        {
            GetObject();
            Spawn?.Invoke();
            yield return _wait;
        }
    }
}