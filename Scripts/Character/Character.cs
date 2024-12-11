using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector2 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    public void Restart()
    {
        transform.position = _position;
    }
}