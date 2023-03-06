using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ShootingController : MonoBehaviour
    {
        [Header("Customization")]
        public GameObject bulletType;

        [Header("Bullets")]
        public List<GameObject> bullets = new List<GameObject>();
        public int currentBulletCount = 0;
        public int initialCapacity = 3;

        [Header("ShootingSettings")]
        public float shootingTimer;
        public float bulletSpeed;
        public float shootingSpeed;
        public float bulletPower;
        protected bool canShoot;

        [HideInInspector] public bool inputDetected = false;

        public bool isEnemyTurret = false;

        // Resets
        protected float baseShootingTimer;

        // Switches
        [SerializeField] bool autoShoot = false;

        // Start is called before the first frame update
        void Start()
        {
            baseShootingTimer = shootingTimer;
            BulletPoolInstantiation();
        }

        // Update is called once per frame
        void Update()
        {
            ShootingDelayTimer();
            BulletManager();
        }

        public void BulletPoolInstantiation()
        {
            Transform parentObject = gameObject.transform; // Organizes bullets
            for (int i = 0; i < initialCapacity; i++)
            {
                GameObject bullet = Instantiate(bulletType, parentObject);
                bullets.Add(bullet);
                bullets[i].SetActive(false);
            }
        }

        void BulletManager()
        {
            if (inputDetected || autoShoot)
            {
                inputDetected = false;
                if (canShoot)
                {
                    GetBullet();     
                    ResetShootingDelayTimer();
                }
            }
        }

        public void GetBullet()
        {
            if (bullets.Count > 0)
            {
                // Get the first bullet from the list             
                bullets[0].GetComponent<Bullet>().bulletSpeed = bulletSpeed;
                bullets[0].transform.position = gameObject.transform.position;
                bullets[0].transform.rotation = gameObject.transform.rotation;
                bullets[0].SetActive(true);
                ReturnBullet(bullets[0]);
                bullets.RemoveAt(0);
            }
            else
            {
                // If the pool is empty, create a new bullet
                bulletType = new GameObject();
            }
        }

        void ShootingDelayTimer()
        {
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0)
            {
                shootingTimer = 0;
                canShoot = true;
            }
            else canShoot = false;
        }

        public void ReturnBullet(GameObject bullet)
        {
            // Sets bullet.SetActivate to false
            bullets.Add(bullet);
        }

        public void ResetShootingDelayTimer()
        {
            shootingTimer = baseShootingTimer;
        }
    }
}

