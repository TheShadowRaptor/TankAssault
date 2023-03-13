using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            mainmenu,
            gameplay,
            pause,
            gameover
        }

        public GameState currentGameState;
        GameState previousGameState;

        // Consts
        private const string mainmenuConst = "Mainmenu";
        private const string gameplayConst = "Gameplay";
        private const string pauseConst = "Pause";
        private const string gameoverConst = "Gameover";


        // Properties
        public string MainmenuStateConst { get => mainmenuConst;  }
        public string GameplayStateConst { get => gameplayConst;  }
        public string PauseConst { get => pauseConst;  }
        public string GameoverConst { get => gameoverConst;  }
        public GameState CurrentGameState { get => currentGameState; }
        public GameState PreviousGameState { get => previousGameState; }

        private void Start()
        {
            currentGameState = GameState.mainmenu;
        }

        public void ChangeState(string stateName)
        {
            // Saves previous state
            previousGameState = currentGameState;

            switch (stateName)
            {
                case mainmenuConst:
                    currentGameState = GameState.mainmenu;
                    Time.timeScale = 1;
                    break;

                case gameplayConst:
                    currentGameState = GameState.gameplay;
                    Time.timeScale = 1;
                    break;

                case pauseConst:
                    currentGameState = GameState.pause;
                    Time.timeScale = 1;
                    break;

                case gameoverConst:
                    currentGameState = GameState.gameover;
                    Time.timeScale = 1;
                    break;
            }
        }

        public void ChangeStateToPrevious()
        {
            currentGameState = previousGameState;
        }
    }
}
