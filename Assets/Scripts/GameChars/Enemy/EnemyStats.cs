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

        //[Header("Movement Settings")]
        [SerializeField] protected int turnSpeed;

        [Header("Components")]
        [SerializeField] protected Animator animator;

        [Header("Settings")]
        [SerializeField] protected int pointsOnDeath;
        [SerializeField] protected List<GameObject> drops = new List<GameObject>();
        int dropChance;


        // Gets/Sets
        //---------------------------------------------------------------
        public int TurnSpeed { get => turnSpeed; }
        //===============================================================

        //AudioSource
        protected AudioSource audioSource;

        // Switches
        protected bool startDeath = false;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            InitResetStats();
        }

        void Update()
        {
            CheckStatus();

            if (isAlive)
            {
                animator.SetBool("isDying", false);
                Activate();
            }

            else
            {
                if (!startDeath)
                {
                    MasterSingleton.MS.uIManager.hUDManager.AddPoints(pointsOnDeath);
                    dropChance = Random.Range(0, drops.Count + 5);
                    if (dropChance <= drops.Count - 1) Instantiate(drops[dropChance], this.gameObject.transform.position, Quaternion.identity);
                    MasterSingleton.MS.audioManager.StopAudio(audioSource);
                    MasterSingleton.MS.audioManager.PlayAudio(audioSource, MasterSingleton.MS.audioManager.enemySlain);
                    animator.SetBool("isDying", true);
                    startDeath = true;
                }
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName("Death") && stateInfo.normalizedTime >= 1.0f) Deactivate();
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
