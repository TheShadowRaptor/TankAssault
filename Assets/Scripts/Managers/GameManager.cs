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
            pause
        }

        GameState currentGameState;
        GameState previousGameState;

        // Consts
        private const string mainmenuConst = "Mainmenu";
        private const string gameplayConst = "Gameplay";
        private const string pauseConst = "Pause";


        // Properties
        public string MainmenuStateConst { get => mainmenuConst;  }
        public string GameplayStateConst { get => gameplayConst;  }
        public string PauseConst { get => pauseConst;  }
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
                    break;

                case gameplayConst:
                    currentGameState = GameState.gameplay;
                    break;

                case pauseConst:
                    currentGameState = GameState.pause;
                    break;
            }
        }

        public void ChangeStateToPrevious()
        {
            currentGameState = previousGameState;
        }
    }
}
