using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    public Transform forwardTransform;
    public float moveSpeed = 3f;

    private Rigidbody _rigidBody;
    private Vector2 _direction;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 forward = forwardTransform.forward;
        Vector3 right = forwardTransform.right;
        forward.y = 0f;
        forward.Normalize();
        right.y = 0f;
        right.Normalize();

        Vector2 direction = moveSpeed * Time.fixedDeltaTime * _direction;
        Vector3 newPos = (direction.y * forward) + (direction.x * right) + _rigidBody.position;
        _rigidBody.MovePosition(newPos);
    }
}
