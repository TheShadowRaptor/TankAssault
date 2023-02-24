using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Raycast")]
        public LayerMask ground;

        [Header("GameObjects")]
        public Rigidbody2D turretRb;

        [Header("Scripts")]
        public ShootingController playerShootingController;

        // Scripts
        PlayerStats _playerStats;

        // Components
        Rigidbody2D rb2D;

        // Input
        float turretRotationInput;
        float movementInput;
        bool jumpInput;
        bool shootInput;

        // Gets/Sets
        public float TurretRotationInput { get => turretRotationInput; }
        public float MovementInput { get => movementInput; }
        public bool JumpInput { get => jumpInput; }
        public bool ShootInput { get => shootInput; }
        //---------------------------------------------------------------

        // Start is called before the first frame update
        void Start()
        {
            rb2D = this.gameObject.GetComponent<Rigidbody2D>();
            _playerStats = this.gameObject.GetComponent<PlayerStats>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();            
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleInput()
        {
            // Reads Input
            if (MasterSingleton.MS.gameManager.CurrentGameState != GameManager.GameState.gameplay) return;
            movementInput = Input.GetAxis("Horizontal");
            turretRotationInput = Input.GetAxis("Horizontal2");
            jumpInput = Input.GetButton("Jump");
            shootInput = Input.GetButton("Shoot");

            // Calls to other scripts
            if (shootInput)
            {
                playerShootingController.inputDetected = true;
            }
        }

        void HandleMovement()
        {
            // Moves/Jump Player if on ground
            if (Grounded())
            {
                Vector2 playerMovement = new Vector2(movementInput * _playerStats.MovementSpeed, jumpValue());
                rb2D.velocity = playerMovement;
            }

            HandleTurretTurning();
        }

        void HandleTurretTurning()
        {
            float rotationAmount = turretRotationInput * _playerStats.RotationSpeedTurret * Time.deltaTime;

            // Rotate the turret game object around its z-axis (which is pointing up)
            turretRb.transform.Rotate(0f, 0f, rotationAmount);
        }        

        //Returns jump value when input is pressed and fully charged
        float jumpValue()
        {
            if (jumpInput && _playerStats.JumpFullyCharged)
            {
                _playerStats.ResetJumpCharge();
                return _playerStats.JumpPower;
            }

            return 0;
        }

        bool Grounded()
        {
            // Checks if player is touching the ground
            float dist = 0.5f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, dist, ground);
            if (hit.collider != null)
            {
                return true;
            }
            else
            {               
                return false;
            }
        }
    }
}
