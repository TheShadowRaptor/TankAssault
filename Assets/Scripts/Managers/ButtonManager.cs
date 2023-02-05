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
    
        // Methods
        public void TitleOnButton()
        {
            // Changes states of GameManager and UI manager on button pressed
            MasterSingleton.MS.gameManager.ChangeState(MasterSingleton.MS.gameManager.MainmenuStateConst);
            MasterSingleton.MS.uIManager.ChangeState(MasterSingleton.MS.uIManager.TitleStateConst);

            if (MasterSingleton.MS.gameManager.CurrentGameState == GameManager.GameState.gameplay)
            {
                // Only loads title when gameState == gameplay
                MasterSingleton.MS.levelManager.LoadScene(titleSceneConst);
            }
        }

        public void SettingsOnButton()
        {
            // Changes state of UIManager on button press
            MasterSingleton.MS.uIManager.ChangeState(MasterSingleton.MS.uIManager.SettingsStateConst);
        }

        public void GameplayOnButton()
        {
            MasterSingleton.MS.gameManager.ChangeState(MasterSingleton.MS.gameManager.GameplayStateConst);
            MasterSingleton.MS.levelManager.LoadScene(gameplaySceneConst);
        }

        public void BackButton()
        {
            MasterSingleton.MS.uIManager.ChangeStateToPrevious();
        }

        public void ExitGameButton()
        {
            MasterSingleton.MS.levelManager.ExitGame();
            Debug.Log("Exit");
        }
    }
}
