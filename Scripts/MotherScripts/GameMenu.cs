using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private Character _character;
    [SerializeField] private CollisionHandler _characterCollisionHandler;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnPlayButtonClick;
        _characterCollisionHandler.GettingHit += Death;
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnPlayButtonClick;
        _characterCollisionHandler.GettingHit += Death;
    }

    private void OnPlayButtonClick()
    {
        _character.Restart();
        _pointsViewer.Restart();
        Time.timeScale = 1f;
        _startScreen.Close();
        _endScreen.Close();
    }

    private void Death()
    {
        Time.timeScale = 0f;
        _endScreen.Open();
    }
}