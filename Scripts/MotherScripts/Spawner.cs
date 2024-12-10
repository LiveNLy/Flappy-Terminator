using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : Prefab
{
    [SerializeField] protected Prefab[] _prefab;
    [SerializeField] protected SpawnPoint[] _spawnPoints;

    private int _poolDefaultCapacity = 7;
    private int _poolMaxSize = 7;

    private ObjectPool<Prefab> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Prefab>(
            actionOnGet: (prefab) => SetObject(prefab),
            createFunc: () => InstantiatePrefab(),
            actionOnRelease: (prefab) => prefab.gameObject.SetActive(false),
            actionOnDestroy: (prefab) => Destroy(prefab),
            collectionCheck: true,
            defaultCapacity: _poolDefaultCapacity,
            maxSize: _poolMaxSize);
    }

    public void ReleaseObject(Prefab prefab)
    {
        _pool.Release(prefab);
    }

    public void GetObject()
    {
        _pool.Get();
    }

    protected virtual Prefab InstantiatePrefab()
    {
        return Instantiate(_prefab[0]);
    }

    protected virtual void SetObject(Prefab prefab)
    {
        prefab.transform.position = _spawnPoints[0].transform.position;
        prefab.gameObject.SetActive(true);
    }
}