using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ResetManager : MonoBehaviour
    {
        public void RunReset()
        {
            MasterSingleton.MS.playerController.PlayerStats.ResetStats();
            MasterSingleton.MS.playerController.playerShootingController.ResetStats();
            MasterSingleton.MS.uIManager.hUDManager.ResetStats();
            MasterSingleton.MS.levelManager.waveManager.ResetStats();
        }
    }
}
