using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private CharacterController _controller;
    private float _gravity = 9.8f;
    private float _defaultYValue = 0f;
    private float _yPosition;
    private float _speed = 5;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = GetAxisValue(Horizontal);
        float vertical = GetAxisValue(Vertical);

        Vector3 move = new Vector3(horizontal, _yPosition, vertical);
        _controller.Move(move * _speed * Time.deltaTime);

        SetYPosition();
    }

    private void SetYPosition()
    {
        if (_controller.isGrounded)
            _yPosition = _defaultYValue;
        else
            _yPosition -= _gravity * Time.deltaTime;
    }

    private float GetAxisValue(string axis)
    {
        return Input.GetAxis(axis);
    }
}
