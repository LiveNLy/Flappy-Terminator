using System;
using System.Collections;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private float _delay = 1.5f;

    private float _delayBeforeShoot = 0f;
    private float _delayReduce = 0.5f;
    private Coroutine _coroutine;

    public event Action Jumped;
    public event Action JumpAnimating;
    public event Action Shooted;

    private void Update()
    {
        ShootInput();
        JumpInput();
    }

    private void ShootInput()
    {
        if (Input.GetKeyUp(KeyCode.D) && _delayBeforeShoot <= 0 && _coroutine == null)
        {
            Shooted?.Invoke();
            _delayBeforeShoot = _delay;
            _coroutine = StartCoroutine(Delay());
        }
    }

    private void JumpInput()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            JumpAnimating?.Invoke();
            Jumped?.Invoke();
        }
    }

    private IEnumerator Delay()
    {
        while (_delayBeforeShoot > 0)
        {
            _delayBeforeShoot -= _delayReduce;

            yield return new WaitForSeconds(0.5f);
        }

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}