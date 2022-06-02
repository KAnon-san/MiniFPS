using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniFPS
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;

        private Vector3 _moveDirection = Vector3.right;
        private CharacterController _characterController;

        private void OnEnable()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            var moveVector = _moveDirection;
            _characterController.Move(moveVector * _moveSpeed);
        }

        private void ChangeDirection()
        {
            if (_moveDirection == Vector3.right)
                _moveDirection = Vector3.left;
            else
                _moveDirection = Vector3.right;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(Tags.EnemyObstacleTag))
            {
                ChangeDirection();
            }
        }
    }
}