using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class MasterSingleton : MonoBehaviour
    {
        public static MasterSingleton Instance { get; private set; }

        //[Header("Scripts")]
        public GameManager GameManager;

        // Awake is called before start
        private void Awake()
        {
            // Singleton
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
                Instance = this;
        }
    }
}
