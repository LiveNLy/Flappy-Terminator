using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private CollisionHandler _character;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private float _delaySpeed;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.2f);
    private Coroutine _coroutine;

    public event Action RestartGame;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClick += OnPlayButtonClick;
        _character.GettingHit += Death;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClick -= OnPlayButtonClick;
        _character.GettingHit += Death;
    }

    private void OnPlayButtonClick()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        RestartGame?.Invoke();
        Time.timeScale = 1.0f;
        _startScreen.Close();
        _endScreen.Close();
    }

    private void Death()
    {
        _coroutine = StartCoroutine(DelayEndScreen());
        _endScreen.Open();
    }

    private IEnumerator DelayEndScreen()
    {
        while (Time.timeScale > 0.2f)
        {
            Time.timeScale -= _delaySpeed;

            yield return _waitForSeconds;
        }

        Time.timeScale = 0f;
    }
}