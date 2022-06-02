using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFPS.UI
{
    [RequireComponent(typeof(Image))]
    public class AimGUI : MonoBehaviour
    {
        [SerializeField]
        private Color _lookAtEnemyColor;

        private Color _startColor;
        private Image _aimImage;

        private void OnEnable()
        {
            _aimImage = GetComponent<Image>();
            _startColor = _aimImage.color;
        }

        public void SetLookAtEnemy()
        {
            _aimImage.color = _lookAtEnemyColor;
        }

        public void SetDefault()
        {
            _aimImage.color = _startColor;
        }
    }
}