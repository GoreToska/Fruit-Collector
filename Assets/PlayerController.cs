using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _speed;
    [Range(0f, 0.3f)]
    [SerializeField] private float _distanceTreshold;
    private bool _isMoving = false;
    private bool _isRotating = false;
    private Rigidbody _rigidbody;
    private Quaternion _nextRotation;

    public bool IsMoving { get { return _isMoving; } }
    public bool IsRotating { get { return _isRotating; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        PlayerInputReader.SwipeAction += GetNewRotation;
    }

    private void OnDisable()
    {
        PlayerInputReader.SwipeAction -= GetNewRotation;
    }

    private void LateUpdate()
    {
        if (!_isMoving)
            return;

        MovePlayer();

        if (_isRotating)
        {
            RotatePlayer(_nextRotation);
        }
    }

    private void MovePlayer()
    {
        _rigidbody.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * _speed);
    }

    private void Start()
    {
        StartMovement();
    }

    private void GetNewRotation(Vector2 input)
    {
        if (input.x == 1)
        {
            _nextRotation = Quaternion.Euler(0, 0, 0);
            _isRotating = true;
        }
        if (input.x == -1)
        {
            _nextRotation = Quaternion.Euler(0, 180, 0);
            _isRotating = true;
        }
        if (input.y == 1)
        {
            _nextRotation = Quaternion.Euler(0, -90, 0);
            _isRotating = true;
        }
        if (input.y == -1)
        {
            _nextRotation = Quaternion.Euler(0, 90, 0);
            _isRotating = true;
        }
    }

    public void StartMovement()
    {
        _isMoving = true;
    }

    public void StopMovement()
    {
        _isMoving = false;
    }

    private void RotatePlayer(Quaternion newRotation)
    {
        if (newRotation == null)
            return;

        Vector3 currentDistance = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));

        if (Vector3.Distance(transform.position, currentDistance) < _distanceTreshold)
        {
            _rigidbody.rotation = newRotation;
            _isRotating = false;
        }
    }
}
