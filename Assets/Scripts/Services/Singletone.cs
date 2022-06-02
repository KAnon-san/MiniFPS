using System.Collections;
using UnityEngine;

namespace MiniFPS
{
    public abstract class Singletone<T> : MonoBehaviour
        where T: Singletone<T>
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}