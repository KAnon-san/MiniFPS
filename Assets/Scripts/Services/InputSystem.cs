using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

namespace MiniFPS
{
    public class InputSystem : Singletone<InputSystem>
    {
        [SerializeField]
        private KeyCode _forwardButton;

        [SerializeField]
        private KeyCode _backButton;

        [SerializeField]
        private KeyCode _leftButton;

        [SerializeField]
        private KeyCode _rightButton;

        [SerializeField]
        private KeyCode _shotButton;

        public bool ShotButtonDown => Input.GetKeyDown(_shotButton);

        public int ForwardMoveAxis => GetMovementAxis(_backButton, _forwardButton);
        public int StrafeMoveAxis => GetMovementAxis(_leftButton, _rightButton);

        public float XMouseAxis => Input.GetAxis("Mouse X");
        public float YMouseAxis => Input.GetAxis("Mouse Y");

        private int GetMovementAxis(KeyCode negativeAxis, KeyCode positiveAxis)
        {
            if (Input.GetKey(positiveAxis)) return 1;
            if (Input.GetKey(negativeAxis)) return -1;
            return 0;
        }
    }
}