using System.Collections;
using TMPro;
using UnityEngine;

namespace MiniFPS
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        private const float Gravity = 9.8f;

        [SerializeField]
        private float _movementSpeed;

        private Vector3 _freeFallVelocity;
        private Vector3 _pushVelocity;

        private CharacterController _characterController;
        private InputSystem _input;

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _input = InputSystem.Instance;
        }

        private void FixedUpdate()
        {
            HandleMovement();
            HandlePush();
        }

        private void Update()
        {
            HandleGravity();
        }

        public void Push(Vector3 direction)
        {
            _pushVelocity += direction;
        }

        private void HandleMovement()
        {
            var zOffset = _input.ForwardMoveAxis * _movementSpeed;
            var xOffset = _input.StrafeMoveAxis * _movementSpeed;

            var moveDirection = new Vector3(xOffset, 0, zOffset);
            var moveVector = transform.TransformDirection(moveDirection.normalized * _movementSpeed);
            moveVector.y = 0;
            moveVector = Vector3.ClampMagnitude(moveVector, _movementSpeed);

            _characterController.Move(moveVector);
        }

        private void HandlePush()
        {
            _characterController.Move(_pushVelocity);
            _pushVelocity = Vector3.Lerp(_pushVelocity, Vector3.zero, 0.1f);
        }

        private void HandleGravity()
        {
            var isGrounded = _characterController.isGrounded;

            if (isGrounded)
            {
                _freeFallVelocity = Vector3.zero;
            }
            else
            {
                _freeFallVelocity.y -= Gravity * Time.deltaTime * Time.deltaTime;
            }

            _characterController.Move(_freeFallVelocity);
        }
    }
}