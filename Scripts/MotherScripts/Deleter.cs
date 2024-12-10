using UnityEngine;

public class Deleter<T> : MonoBehaviour where T : Prefab
{
    [SerializeField] private Spawner<T> _spawner;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out T obj))
        {
            _spawner.GetObject();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out T obj))
        {
            _spawner.ReleaseObject(obj);
        }
    }
}