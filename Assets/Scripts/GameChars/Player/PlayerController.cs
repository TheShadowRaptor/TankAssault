using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Raycast")]
        public LayerMask ground;
        public float rayDist = 0.5f;

        [Header("GameObjects")]
        public Rigidbody2D turretRb;

        [Header("Scripts")]
        public ShootingController playerShootingController;

        // Scripts
        PlayerStats playerStats;

        // Components
        Rigidbody2D rb2D;

        // Input
        float turretRotationInput;
        float movementInput;
        bool jumpInput;
        bool shootInput;

        // Gets/Sets
        public PlayerStats PlayerStats { get => playerStats; }
        public float TurretRotationInput { get => turretRotationInput; }
        public float MovementInput { get => movementInput; }
        public bool JumpInput { get => jumpInput; }
        public bool ShootInput { get => shootInput; }
        //---------------------------------------------------------------

        //AudioSource
        protected AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            rb2D = this.gameObject.GetComponent<Rigidbody2D>();
            playerStats = this.gameObject.GetComponent<PlayerStats>();
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
            if (MasterSingleton.MS.gameManager.CurrentGameState == GameManager.GameState.gameover) return;
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
                Vector2 playerMovement = new Vector2(movementInput * playerStats.MovementSpeed, jumpValue());
                rb2D.velocity = playerMovement;
            }

            HandleTurretTurning();
            CameraBounds();
        }

        void HandleTurretTurning()
        {
            float rotationAmount = turretRotationInput * playerStats.TurretRotationSpeed * Time.deltaTime;

            // Rotate the turret game object around its z-axis (which is pointing up)
            turretRb.transform.Rotate(0f, 0f, rotationAmount);
        }  
        
        void CameraBounds()
        {
            Vector3 pos = gameObject.transform.position;
            Vector3 camBounds = new Vector3(Camera.main.orthographicSize * 1.65f, Camera.main.orthographicSize, 0);
            Vector3 camPos = Camera.main.transform.position;
            if (pos.x > camBounds.x + camPos.x) pos.x = camBounds.x + camPos.x;
            if (pos.x < -camBounds.x + camPos.x) pos.x = -camBounds.x + camPos.x;
            if (pos.y > camBounds.y + camPos.y - 3) pos.y = camBounds.y + camPos.y - 3;
            if (pos.y < -camBounds.y + camPos.y + 1) pos.y = -camBounds.y + camPos.y + 1;
            gameObject.transform.position = pos;
        }

        //Returns jump value when input is pressed and fully charged
        float jumpValue()
        {
            if (jumpInput)
            {
                //_playerStats.ResetJumpCharge();
                return playerStats.JumpPower;
            }

            return 0;
        }

        bool Grounded()
        {
            // Checks if player is touching the ground
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, rayDist, ground);
            if (hit.collider != null)
            {
                return true;
            }
            else
            {               
                return false;
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                // Take Damage from enemy bullet
                //Debug.Log("hit");
                int damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
                this.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                MasterSingleton.MS.audioManager.StopAudio(audioSource);
                MasterSingleton.MS.audioManager.PlayAudio(audioSource, MasterSingleton.MS.audioManager.playerHurt);
                other.gameObject.GetComponent<Bullet>().Deactivate();
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                int damage = other.gameObject.GetComponent<EnemyStats>().BodyDamage;
                this.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                MasterSingleton.MS.audioManager.StopAudio(audioSource);
                MasterSingleton.MS.audioManager.PlayAudio(audioSource, MasterSingleton.MS.audioManager.playerHurt);
                other.gameObject.GetComponent<EnemyStats>().TakeDamage(1000);
            }
        }
    }
}
