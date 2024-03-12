using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 75f;
    [SerializeField] private float _walkspeed = 8f;
    [SerializeField] private float _runSpeed = 24f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _characterController;
    private Camera _playerCamera;

    private Vector3 _velocity;
    private Vector2 _rotation;
    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(motion:_velocity * Time.deltaTime);
        _direction = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));
        Vector2 mouseDelta = new Vector2(x: Input.GetAxis("Mouse X"), y: Input.GetAxis("Mouse Y"));

        if (_characterController.isGrounded) _velocity.y = Input.GetKeyDown(KeyCode.Space) ? _jumpForce : -0.1f;
        else _velocity.y += _gravity + Time.deltaTime;

        mouseDelta *= _rotateSpeed * Time.deltaTime;
        _rotation.y += mouseDelta.x;
        _rotation.x = Mathf.Clamp(value:_rotation.x - mouseDelta.y, min:-90, max: 90);
        _playerCamera.transform.localEulerAngles = (Vector3)_rotation;
       

    }

    private void FixedUpdate()
    {
        _direction *= Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkspeed;
        Vector3 move = Quaternion.Euler(x:0, _playerCamera.transform.eulerAngles.y, z: 0) * new Vector3(_direction.x, y:0, z:_direction.y);
        _velocity = new Vector3(move.x, _velocity.y, move.z);
    }
}
