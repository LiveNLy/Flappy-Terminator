using UnityEngine;

public class Character : MonoBehaviour 
{
    [SerializeField] private GameMenuController _game;

    private Vector2 _position;

    private void Awake()
    {
        _position = transform.position;
    }

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
        transform.position = _position;
    }
}