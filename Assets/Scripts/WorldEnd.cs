using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public class WorldEnd : MonoBehaviour
    {
        private LevelService _levelService;

        private void Start()
        {
            _levelService = LevelService.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PlayerTag))
            {
                _levelService.Lose();
            }
        }
    }
}