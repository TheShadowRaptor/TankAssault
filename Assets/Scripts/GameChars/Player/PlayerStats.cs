using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerStats : CharacterStats
    {
        // Reset values
        float jumpChargeReset;
        int healthReset;
        int movementSpeedReset;
        int turretRotationSpeedReset;
        int jumpPowerReset;

        // Variables
        [Header("Movement Settings")]
        [SerializeField] private int turretRotationSpeed;
        [SerializeField] private int jumpPower;

        [Header("JumpCharge Settings")]
        private float jumpCharge = 1;
        private bool jumpFullyCharged;

        // Gets/Sets
        public int TurretRotationSpeed { get => turretRotationSpeed; }
        public int JumpPower { get => jumpPower; }
        //---------------------------------------------------------------
        public float JumpChargeReset { get => jumpChargeReset; }
        public float JumpCharge { get => jumpCharge; }
        public bool JumpFullyCharged { get => jumpFullyCharged; }
        //===============================================================

        // Start is called before the first frame update
        void Start()
        {
            // init
            InitResetStats();
        }

        protected void Update()
        {
            CheckStatus();
            HandleJumpCharge();
            if (!isAlive)
            {
                CallGameover();
            }
        }

        void CallGameover()
        {
            MasterSingleton.MS.gameManager.ChangeState(MasterSingleton.MS.gameManager.GameoverConst);
        }

        void HandleJumpCharge()
        {
            float chargeIncrease = 0.5f;

            jumpCharge += chargeIncrease * Time.deltaTime;
            if (jumpCharge >= jumpChargeReset)
            {
                jumpCharge = jumpChargeReset;
                jumpFullyCharged = true;
            }
            else jumpFullyCharged = false;
        }

        public void ResetJumpCharge()
        {
            jumpCharge = 0;
        }

        public override void ResetStats()
        {
            health = healthReset;
            movementSpeed = movementSpeedReset;
            jumpCharge = jumpChargeReset;
            turretRotationSpeed = turretRotationSpeedReset;
            jumpPower = jumpPowerReset;
        }
        void InitResetStats()
        {
            healthReset = health;
            movementSpeedReset = movementSpeed;
            jumpChargeReset = jumpCharge;
            turretRotationSpeedReset = turretRotationSpeed;
            jumpPowerReset = jumpPower;
        }
    }
}
