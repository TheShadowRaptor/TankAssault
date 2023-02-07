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

        [Header("Bullets")]
        public GameObject bulletSpawnerObj;
        public GameObject bulletObj;
        public List<GameObject> ammo = new List<GameObject>();

        // Scripts
        PlayerStats _playerStats;

        // Components
        Rigidbody2D rb2D;

        // Input
        float rotationInputTurret;
        float movementInput;
        bool jumpInput;
        bool shootInput;

        // switches
        // bool jumping = false;

        // Start is called before the first frame update
        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            _playerStats = GetComponent<PlayerStats>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();            
            HandleShooting();
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
            rotationInputTurret = Input.GetAxis("Horizontal2");
            jumpInput = Input.GetButton("Jump");
            shootInput = Input.GetButton("Shoot");

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
            turretRb.MoveRotation(turretRb.transform.localRotation * Quaternion.Euler(0, 0, -rotationInputTurret * _playerStats.RotationSpeedTurret * Time.deltaTime));
        }

        void HandleShooting()
        {
            if (shootInput && _playerStats.CanShoot)
            {
                Debug.Log("Shooting");

                GameObject bullet = Instantiate(bulletObj);
                ammo.Add(bullet);
                bullet.transform.position = bulletSpawnerObj.transform.position;
                _playerStats.ResetShootingTimer();
            }

            if (ammo.Count > 0)
            {
                foreach (GameObject bullet in ammo)
                {
                    Vector3 bulletPos = bullet.transform.position;
                    bulletPos.y += _playerStats.ShootingSpeed * Time.deltaTime;
                    bullet.transform.position = bulletPos;
                    Debug.Log("BulletSpeed " + bulletPos.y);
                }
            }
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
