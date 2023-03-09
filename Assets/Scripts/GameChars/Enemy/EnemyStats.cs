using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class EnemyStats : CharacterStats
    {
        // Reset values
        int healthReset;
        int movementSpeedReset;

        // Start is called before the first frame update
        void Start()
        {
            InitResetStats();
        }

        void Update()
        {
            CheckStatus();

            if (isAlive) Activate();
            else Deactivate();
        }

        public override void ResetStats()
        {
            health = healthReset;
            movementSpeed = movementSpeedReset;
        }

        void InitResetStats()
        {
            healthReset = health;
            movementSpeedReset = movementSpeed;
        }
    }
}
