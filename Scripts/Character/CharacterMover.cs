using System.Collections;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;

    private bool _isJump;

    private void OnEnable()
    {
        _inputReader.Jumped += JumpAction;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= JumpAction;
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            _rigidbody.velocity = _jumpPower * Vector2.up;
            _isJump = false;
        }
    }

    private void JumpAction()
    {
        _isJump = true;
    }
}