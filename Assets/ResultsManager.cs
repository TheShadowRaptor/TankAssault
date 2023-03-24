using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TankAssault
{
    public class ResultsManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI waveText;
        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + MasterSingleton.MS.uIManager.hUDManager.Score;
            waveText.text = "Wave: " + MasterSingleton.MS.levelManager.waveManager.waveCounter;
        }
    }
}
