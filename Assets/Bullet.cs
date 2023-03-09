using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class Bullet : MonoBehaviour
    {
        [HideInInspector] public float bulletSpeed;
        [HideInInspector] public int bulletDamage;

        [Header("Toggle this if used for enemy")]
        public bool isEnemyBullet = true;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            Vector3 direction;

            if (isEnemyBullet) direction = -transform.up;
            else direction = transform.up;

            gameObject.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
