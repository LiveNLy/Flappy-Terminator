using System.Collections;
using TMPro;
using UnityEngine;

public class PointsViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;

    private Coroutine _coroutine;
    private WaitForSeconds _wait = new WaitForSeconds(0.3f);
    private int _count = 0;

    private void Start()
    {
        _coroutine = StartCoroutine(Counter());
    }

    public void Restart()
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