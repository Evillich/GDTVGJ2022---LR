using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [System.Serializable]
    public struct MovementParams
    {
        public float walkSpeed;
        public float backwalkSpeed;
        public float strafeSpeed;
        public float sprintSpeed;
        public float jumpstartSpeed;
    }

    [SerializeField] public bool isMoving;
    [SerializeField] public Vector3 direction;
    [SerializeField] public float speed;

    [SerializeField] private MovementParams _movementParams;
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }
    public void SetVelocity(Vector3 direction, float speed)
    {
        SetVelocity(direction * speed);
    }

    public void SetVelocity(MovementInput input)
    {
        if (input.cameraBasis == null)
            SetVelocity(InputToVelocity(input));
        else
            SetVelocity(WorldDirectionToCameraDirection(input));
    }

    [SerializeField] private float groundedTolerance = 1.15f;

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundedTolerance);
    }



    private Vector3 InputToVelocity(MovementInput input)
    {
        float z = input.direction.z >= 0 ? input.direction.z * (input.isSprinting ? _movementParams.sprintSpeed : _movementParams.walkSpeed) : input.direction.z * _movementParams.backwalkSpeed;
        float y = _rigidbody.velocity.y + (IsGrounded() ? input.direction.y * _movementParams.jumpstartSpeed : 0f);
        float x = input.direction.x * _movementParams.strafeSpeed;
        return new Vector3(x,y,z);
    }

    private Vector3 WorldDirectionToCameraDirection(MovementInput input)
    {
        var a = InputToVelocity(input);
        var y = a.y;
        a = new Vector3(a.x, 0, a.z);

        var b = input.cameraBasis.worldToLocalMatrix.inverse;
        var c = b * a;

        var result = new Vector3(c.x, y, c.z);
        return result;
    }
 


    void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        isMoving = _rigidbody.velocity != Vector3.zero;
        if (!isMoving)
        {
            speed = 0;
            direction = Vector3.zero;
            return;
        }

        speed = _rigidbody.velocity.magnitude;
        direction = _rigidbody.velocity.normalized;
        //isGrounded = IsGrounded();
    }
}
