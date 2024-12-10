using System.Collections;
using TMPro;
using UnityEngine;

public class PointsViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    [SerializeField] private GameMenuController _gameMenuController;

    private Coroutine _coroutine;
    private WaitForSeconds _wait = new WaitForSeconds(0.3f);
    private int _count = 0;

    private void OnEnable()
    {
        _gameMenuController.RestartGame += Restart;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Counter());
    }

    private void OnDisable()
    {
        _gameMenuController.RestartGame -= Restart;
    }

    private void Restart()
    {
        _count = 0;
    }

    private IEnumerator Counter()
    {
        while (enabled)
        {
            _textCounter.text = $"{_count}";
            _count++;

            yield return _wait;
        }
    }
}