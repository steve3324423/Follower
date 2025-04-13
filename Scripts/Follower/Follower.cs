using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Follower : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Rigidbody _rigidbody;
    private float _minDistance = 1.5f;
    private float _speed = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        TryGoToPlayer();
    }

    private void TryGoToPlayer()
    {
        Vector3 direction = _player.transform.position - transform.position;

        if(direction.sqrMagnitude > _minDistance * _minDistance)
            _rigidbody.MovePosition(transform.position + (direction * _speed * Time.fixedDeltaTime));
    }
}
