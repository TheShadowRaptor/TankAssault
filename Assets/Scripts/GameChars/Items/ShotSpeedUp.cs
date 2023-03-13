using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ShotSpeedUp : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                MasterSingleton.MS.player.playerShootingController.shootingSpeed += 1;
                gameObject.SetActive(false);
            }
        }
    }
}
