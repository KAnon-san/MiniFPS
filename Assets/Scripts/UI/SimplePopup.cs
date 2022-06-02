using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFPS.UI
{
    public class SimplePopup : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}