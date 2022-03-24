using UnityEngine;

namespace SummitRidge.PlayerMove
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform directionReference;
        [SerializeField] private float speed = 7f;
        [SerializeField] private float maxSpeed = 100f;

        [SerializeField] private float accel = 0.125f;
        [SerializeField] private float airControl = .25f;
        [SerializeField] private float friction = .125f;
        [SerializeField] private float minHeight = 1.2f;
        [SerializeField] private float maxHeight = 1.7f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private bool useGravity = true;
        [SerializeField] private bool clampDirection = true;

        private CharacterController _controller;
        private IMoverInput _input;
        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<IMoverInput>();

            if (directionReference == null) directionReference = transform;
        }

        private void Update()
        {
            Debug.Log($"spd: {_moveVelocity.magnitude}");
            
            var direction = directionReference.rotation * new Vector3(_input.Horizontal(), 0f, _input.Vertical());


            if (clampDirection || useGravity)
            {
                direction = Vector3.ProjectOnPlane(direction, Vector3.up);
            }

            if (direction.magnitude > 1f) direction.Normalize();

            _fallVelocity += Vector3.up * gravity * Time.deltaTime;

            _moveVelocity += CalcVelocity(_moveVelocity, direction, speed);
            _controller.height = Mathf.Lerp(_controller.height, _input.IsCrouch() ? minHeight : maxHeight,
                Time.deltaTime / .1f);

            if (_moveVelocity.magnitude > maxSpeed && maxSpeed >= speed)
            {
                _moveVelocity = _moveVelocity * maxSpeed / _moveVelocity.magnitude;
            }

            if (_controller.isGrounded || useGravity == false)
            {
                _fallVelocity = Vector3.zero;
                _moveVelocity -= _moveVelocity * Time.deltaTime / friction;

                if (Input.GetButton("Jump") && useGravity)
                {
                    _fallVelocity = Vector3.up * Mathf.Sqrt(-gravity * jumpHeight * 2f);
                }
            }


            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }

        private Vector3 CalcVelocity(Vector3 velocity, Vector3 wishDirection, float wishSpeed)
        {
            var currentSpeed = Vector3.Dot(velocity, wishDirection);

            var addSpeed = wishSpeed - currentSpeed;
            var accelSpeed = Mathf.Clamp(wishSpeed * Time.deltaTime / accel * (_controller.isGrounded ? 1f : airControl), 0f, addSpeed);

            return wishDirection * accelSpeed;
        }
    }
}