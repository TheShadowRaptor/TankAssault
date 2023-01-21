using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ButtonManager : MonoBehaviour
    {
        // Const
        private const string titleSceneConst = "Scenes/Title";
        private const string gameplaySceneConst = "Scenes/Gameplay";

        // Scripts
        [Header("Scripts")]
        public GameManager _gameManager;
        public UIManager _uIManager;
        public LevelManager _levelManager;
    
        // Methods
        public void TitleOnButton()
        {
            // Changes states of GameManager and UI manager on button pressed
            _gameManager.ChangeState(_gameManager.MainmenuStateConst);
            _uIManager.ChangeState(_uIManager.TitleStateConst);

            if (_gameManager.CurrentGameState == GameManager.GameState.gameplay)
            {
                // Only loads title when gameState == gameplay
                _levelManager.LoadScene(titleSceneConst);
            }
        }

        public void SettingsOnButton()
        {
            // Changes state of UIManager on button press
            _uIManager.ChangeState(_uIManager.SettingsStateConst);
        }

        public void GameplayOnButton()
        {
            _gameManager.ChangeState(_gameManager.GameplayStateConst);
            _levelManager.LoadScene(gameplaySceneConst);
        }

        public void BackButton()
        {
            _uIManager.ChangeStateToPrevious();
        }

        public void ExitGameButton()
        {
            _levelManager.ExitGame();
            Debug.Log("Exit");
        }
    }
}
