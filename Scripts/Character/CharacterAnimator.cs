using System.Collections;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string Jump = nameof(Jump);

    [SerializeField] private int _maxFramesTillFall = 2;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private Coroutine _coroutine;
    private WaitForEndOfFrame _wait = new WaitForEndOfFrame();

    private void OnEnable()
    {
        _inputReader.JumpAnimating += StartAnimation;
    }

    private void OnDisable()
    {
        _inputReader.JumpAnimating -= StartAnimation;
    }

    private void StartAnimation()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(AnimationFallFrameCounter());
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(AnimationFallFrameCounter());
        }
    }

    private IEnumerator AnimationFallFrameCounter()
    {
        float framesTillFall = _maxFramesTillFall;
        _animator.SetBool(Jump, true);

        while (framesTillFall > 0)
        {
            framesTillFall--;
            yield return _wait;
        }

        _animator.SetBool(Jump, false);
    }
}