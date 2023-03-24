using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankAssault
{
    public class LevelManager : MonoBehaviour
    {
        // Scripts
        [Header("Level Scripts")]
        public WaveManager waveManager;
        public GroundGeneration groundGeneration;
        public SceneryGeneration sceneryGeneration;

        // Methods
        private void Update()
        {
            
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
