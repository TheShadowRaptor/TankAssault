using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerStats : CharacterStats
    {
        // Resets
        private float baseJumpCharge;

        // Variables
        [Header("Movement Settings")]
        [SerializeField] private int rotationSpeedTurret;
        [SerializeField] private int jumpPower;

        [Header("JumpCharge Settings")]
        private float jumpCharge = 1;
        private bool jumpFullyCharged;

        // Gets/Sets
        public int RotationSpeedTurret { get => rotationSpeedTurret; }
        public int JumpPower { get => jumpPower; }
        //---------------------------------------------------------------
        public float BaseJumpCharge { get => baseJumpCharge; }
        public float JumpCharge { get => jumpCharge; }
        public bool JumpFullyCharged { get => jumpFullyCharged; }
        //===============================================================

        // Start is called before the first frame update
        void Start()
        {
            // init
            baseJumpCharge = jumpCharge;
        }

        protected override void Update()
        {
            CheckStatus();
            HandleJumpCharge();
        }

        void HandleJumpCharge()
        {
            float chargeIncrease = 0.5f;

            jumpCharge += chargeIncrease * Time.deltaTime;
            if (jumpCharge >= baseJumpCharge)
            {
                jumpCharge = baseJumpCharge;
                jumpFullyCharged = true;
            }
            else jumpFullyCharged = false;
        }

        public void ResetJumpCharge()
        {
            jumpCharge = 0;
        }
    }
}
