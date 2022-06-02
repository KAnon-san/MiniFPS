using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MiniFPS.UI;

namespace MiniFPS
{
    public class LevelService : Singletone<LevelService>
    {
        [SerializeField]
        private Transform _player;

        [SerializeField]
        private SimplePopup _popupPrefab;

        [SerializeField]
        private string _winText;

        [SerializeField]
        private string _loseText;

        private UIService _uiService;
        private int _remainingEnemiesCount;

        public bool AnyEnemiesLeft => _remainingEnemiesCount > 0;
        public Transform Player => _player;

        private void Start()
        {
            _uiService = UIService.Instance;
            _remainingEnemiesCount = FindObjectsOfType<Enemy>().Length;
        }

        public void NotifyEnemyRemoved() => _remainingEnemiesCount--;

        public void Win() => ShowPopupAndComplete(_winText);

        public void Lose() => ShowPopupAndComplete(_loseText);

        private void ShowPopupAndComplete(string popupText)
        {
            var popup = _uiService.ShowUIElement<SimplePopup>(_uiService.ScreenCenter, _popupPrefab);
            popup.SetText(popupText);

            StartCoroutine(ReloadLevel());
        }

        private IEnumerator ReloadLevel()
        {
            yield return new WaitForSecondsRealtime(3f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}