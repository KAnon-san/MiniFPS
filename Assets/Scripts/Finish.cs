using UnityEditor;
using UnityEngine;

namespace MiniFPS
{
    public class Finish : MonoBehaviour
    {
        private LevelService _levelService;

        private void Start()
        {
            _levelService = LevelService.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PlayerTag) && !_levelService.AnyEnemiesLeft)
            {
                _levelService.Win();
            }
        }
    }
}