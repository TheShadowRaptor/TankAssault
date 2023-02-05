using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class MasterSingleton : MonoBehaviour
    {
        public static MasterSingleton MS { get; private set; }
        public GameManager gameManager { get; private set; }
        public UIManager uIManager { get; private set; }
        public LevelManager levelManager { get; private set; }

        // Awake is called before start
        private void Awake()
        {
            // Singleton
            if (MS == null)
            {
                MS = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (MS != this)
            {
                Destroy(gameObject);
                return;
            }

            FindComponents();
        }

        public void FindComponents()
        {
            gameManager = GetComponentInChildren<GameManager>();
            uIManager = GetComponentInChildren<UIManager>();
            levelManager = GetComponentInChildren<LevelManager>();
        }
    }
}
