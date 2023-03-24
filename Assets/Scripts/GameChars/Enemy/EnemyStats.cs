using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class EnemyStats : CharacterStats
    {
        //[Header("Movement Settings")]
        [SerializeField] protected int turnSpeed;

        [Header("Settings")]
        [SerializeField] protected int pointsOnDeath;
        [SerializeField] protected List<GameObject> drops = new List<GameObject>();
        int dropChance;

        // Reset values
        int healthReset;
        int movementSpeedReset;

        // Gets/Sets
        //---------------------------------------------------------------
        public int TurnSpeed { get => turnSpeed; }
        //===============================================================

        // Start is called before the first frame update
        void Start()
        {
            InitResetStats();
        }

        void Update()
        {
            CheckStatus();

            if (isAlive) Activate();
            else
            {
                MasterSingleton.MS.uIManager.hUDManager.AddPoints(pointsOnDeath);
                dropChance = Random.Range(0, drops.Count + 5);
                if (dropChance <= drops.Count) Instantiate(drops[dropChance], this.gameObject.transform.position, Quaternion.identity);
                Deactivate();
            }
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
