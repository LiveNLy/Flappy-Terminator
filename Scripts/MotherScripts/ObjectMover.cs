using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private PointToMove _pointToMove;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointToMove.transform.position, _speed * Time.deltaTime);
    }
}