using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleMovement();
        }

        void HandleMovement()
        {
            // Reads Input
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Moves Player
            Vector3 horizontalMovement = new Vector3(horizontal, 0);
            rb.velocity = horizontalMovement;
        }
    }
}
