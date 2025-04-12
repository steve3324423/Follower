using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _xPositionOffset = 3f;
    private float _speed = 5f;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(_player.transform.position.x + _xPositionOffset,1f,_player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position,targetPosition,_speed * Time.deltaTime);
    }
}
