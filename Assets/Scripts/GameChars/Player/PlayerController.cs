using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Raycast")]
        public LayerMask ground;
        // Scripts
        PlayerStats _playerStats;

        // Components
        Rigidbody2D rb2D;

        // Input
        float horizontalInput;
        bool jumpInput;

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
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleInput()
        {
            // Reads Input
            horizontalInput = Input.GetAxis("Horizontal");
            jumpInput = Input.GetButton("Jump"); 

        }

        void HandleMovement()
        {
            // Moves Player if on ground
            if (Grounded())
            {
                Vector2 playerMovement = new Vector2(horizontalInput * _playerStats.MovementSpeed, jumpValue());
                rb2D.velocity = playerMovement;
            }
        }

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
