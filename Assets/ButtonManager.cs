using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ButtonManager : MonoBehaviour
    {
        // Const
        private const string titleSceneConst = "Title";
        private const string gameplaySceneConst = "Gameplay";

        // Scripts
        [Header("Scripts")]
        public GameManager _gameManager;
        public UIManager _uIManager;
        public LevelManager _levelManager;
    
        // Methods
        public void TitleOnButton()
        {
            _gameManager.ChangeState(_gameManager.MainmenuConst);
            _uIManager.ChangeState(_uIManager.TitleConst);

            if (_gameManager.CurrentGameState == GameManager.GameState.gameplay)
            {
                // Only loads title when gameState == gameplay
                _levelManager.LoadScene(titleSceneConst);
            }
        }

        public void SettingsOnButton()
        {
            _uIManager.ChangeState(_uIManager.SettingsConst);
        }

        public void GameplayOnButton()
        {
            _gameManager.ChangeState(_gameManager.GameplayConst);
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
