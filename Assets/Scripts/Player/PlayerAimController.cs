using System.Collections;
using UnityEngine;
using MiniFPS.UI;

namespace MiniFPS
{
    public class PlayerAimController : MonoBehaviour
    {
        [SerializeField]
        private float _sensitivity = 1f;

        [SerializeField]
        private float _verticalClamp = 45f;

        [SerializeField]
        private AimGUI _aimGUI;

        [SerializeField]
        private Gun _gun;

        private Vector3 LookDirection => _cameraTransform.forward;

        private Transform _cameraTransform;
        private InputSystem _input;

        private float _rotationX;
        private float _rotationY;

        private void Start()
        {
            _input = InputSystem.Instance;
            _cameraTransform = Camera.main.transform;

            LockCursor();
        }

        private void Update()
        {
            HandleRotations();
            HandleShot();
            HandleLookAtEnemy();
        }

        private void LockCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void HandleRotations()
        {
            _rotationX -= _input.YMouseAxis * _sensitivity;
            _rotationY += _input.XMouseAxis * _sensitivity;

            _rotationX = Mathf.Clamp(_rotationX, -_verticalClamp, _verticalClamp);

            _cameraTransform.localEulerAngles = new Vector3(_rotationX, 0, 0);
            transform.localEulerAngles = new Vector3(0, _rotationY, 0);
        }

        private void HandleShot()
        {
            if (_input.ShotButtonDown) 
               _gun.Shot(LookDirection);
        }

        private void HandleLookAtEnemy()
        {
            if (CheckLookAtEnemy())
                _aimGUI.SetLookAtEnemy();
            else
                _aimGUI.SetDefault();
        }

        private bool CheckLookAtEnemy()
        {
            var raycastOrigin = _cameraTransform.position;
            var raycastDirection = LookDirection;

            if (Physics.Raycast(raycastOrigin, raycastDirection, out var hitInfo))
            {
                return hitInfo.collider.gameObject.CompareTag(Tags.EnemyTag);
            }
            return false;
        }
    }
}