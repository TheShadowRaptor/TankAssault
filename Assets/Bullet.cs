using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed;
        public int bulletDamage;
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

            direction = transform.up;
            gameObject.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
