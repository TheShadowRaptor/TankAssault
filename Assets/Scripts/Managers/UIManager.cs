using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TankAssault
{
    public class UIManager : MonoBehaviour
    {
        public enum MainmenuState
        {
            title,
            settings,
            gameover
        }

        public MainmenuState currentMainmenuState;
        MainmenuState previousMainmenuState;

        // Consts
        private const string titleConst = "Title";
        private const string settingsConst = "Settings";

        // Properties
        public string TitleStateConst { get => titleConst; }
        public string SettingsStateConst { get => settingsConst; }

        public MainmenuState CurrentMainmenuState { get => currentMainmenuState; }
        public MainmenuState PreviousMainmenuState { get => previousMainmenuState; }

        // Components
        [Header("Canvas")]
        public Canvas titleCanvas;
        public Canvas settingsCanvas;
        public Canvas gameplayCanvas;
        public Canvas pauseCanvas;
        public Canvas gameoverCanvas;

        //Scripts
        [Header("Scripts")]
        public GameManager _gameManager;

        // Methods
        private void Update()
        {
            // Shows canvas depending on gameState
            switch (_gameManager.CurrentGameState)
            {
                case GameManager.GameState.mainmenu:
                    // Controlled by MainMenuState machine
                    ShowTitleCanvas();
                    ShowSettingsCanvas();
                    break;

                case GameManager.GameState.gameplay:
                    ShowGameplayCanvas();
                    break;

                case GameManager.GameState.pause:
                    ShowPauseCanvas();
                    break;

                case GameManager.GameState.gameover:
                    ShowGameoverCanvas();
                    break;
            }
        }

        void ShowTitleCanvas()
        {
            if (currentMainmenuState == MainmenuState.title)
            {
                titleCanvas.enabled = true;
                settingsCanvas.enabled = false;
                gameplayCanvas.enabled = false;
                pauseCanvas.enabled = false;
                gameoverCanvas.enabled = false;
            }
        }

        void ShowSettingsCanvas()
        {
            if (currentMainmenuState == MainmenuState.settings)
            {
                titleCanvas.enabled = false;
                settingsCanvas.enabled = true;
                gameplayCanvas.enabled = false;
                pauseCanvas.enabled = false;
                gameoverCanvas.enabled = false;
            }
        }

        void ShowGameplayCanvas()
        {
            titleCanvas.enabled = false;
            settingsCanvas.enabled = false;
            gameplayCanvas.enabled = true;
            pauseCanvas.enabled = false;
            gameoverCanvas.enabled = false;
        }

        void ShowPauseCanvas()
        {
            titleCanvas.enabled = false;
            settingsCanvas.enabled = false;
            gameplayCanvas.enabled = false;
            pauseCanvas.enabled = true;
            gameoverCanvas.enabled = false;
        }
        void ShowGameoverCanvas()
        {
            titleCanvas.enabled = false;
            settingsCanvas.enabled = false;
            gameplayCanvas.enabled = false;
            pauseCanvas.enabled = false;
            gameoverCanvas.enabled = true;
        }


        public void ChangeState(string stateName)
        {
            previousMainmenuState = currentMainmenuState;

            switch (stateName)
            {
                case titleConst:
                    currentMainmenuState = MainmenuState.title;
                    break;

                case settingsConst:
                    currentMainmenuState = MainmenuState.settings;
                    break;
            }
        }

        public void ChangeStateToPrevious()
        {
            currentMainmenuState = previousMainmenuState;
        }
    }
}
