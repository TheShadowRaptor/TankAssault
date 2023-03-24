using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TankAssault
{
    public class HUDManager : MonoBehaviour
    {
        public Slider JumpChargeSlider;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI waveText;
        public TextMeshProUGUI healthText;
        public PlayerStats _playerStats;

        int score = 0;

        // Start is called before the first frame update
        void Start()
        {
            InitSliders();
            InitText();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateSliders();
            UpdateText();
        }

        void InitSliders()
        {
            //JumpChargeSlider.maxValue = _playerStats.JumpChargeReset;
            //JumpChargeSlider.value = _playerStats.JumpCharge;
        }

        void UpdateSliders()
        {
            //JumpChargeSlider.value = _playerStats.JumpCharge;
        }

        void InitText()
        {
            scoreText.text = "Score: 0";
            waveText.text = "Wave: 0";
            healthText.text = "Health: 0";
        }

        void UpdateText()
        {
            scoreText.text = "Score: " + score;
            waveText.text = "Wave: " + MasterSingleton.MS.levelManager.waveManager.waveCounter;
            healthText.text = "Health: " + MasterSingleton.MS.playerController.PlayerStats.Health;
        }

        public void AddPoints(int points)
        {
            score += points;
        }

        public void ResetStats()
        {
            score = 0;
            Debug.Log("Reset");
        }
    }
}
