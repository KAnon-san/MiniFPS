using UnityEditor;
using UnityEngine;

namespace MiniFPS.UI
{
    public class UIService : Singletone<UIService>
    {
        [SerializeField]
        private Canvas _canvas;

        private Camera _mainCamera;

        public Vector2 ScreenCenter => new Vector2(Screen.width / 2, Screen.height / 2);

        private void OnEnable()
        {
            _mainCamera = Camera.main;
        }

        public T ShowUIElement<T>(Vector3 screenPosition, T prefab)
            where T : MonoBehaviour
        {
            var uiElement = Instantiate(prefab, _canvas.transform);
            uiElement.transform.position = screenPosition;

            return uiElement;
        }
    }
}