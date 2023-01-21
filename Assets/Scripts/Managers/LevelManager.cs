using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankAssault
{
    public class LevelManager : MonoBehaviour
    {
        // Scripts
        [Header("Scripts")]
        public GameManager _gameManager;

        // Methods
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
