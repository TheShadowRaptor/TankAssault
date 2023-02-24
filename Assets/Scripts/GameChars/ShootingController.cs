using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ShootingController : MonoBehaviour
    {
        [Header("Customization")]
        public List<GameObject> bulletTypes = new List<GameObject>();

        [Header("Bullets")]
        public List<GameObject> ammo = new List<GameObject>();
        public int currentBulletCount = 0;
        public int maxBulletCount = 3;

        [Header("ShootingSettings")]
        public float shootingTimer;
        public float bulletSpeed;
        public float shootingSpeed;
        public float bulletPower;
        protected bool canShoot;

        [HideInInspector] public bool inputDetected = false;

        // Resets
        protected float baseShootingTimer;

        // Switches
        [SerializeField] bool autoShoot = false;

        // Start is called before the first frame update
        void Start()
        {
            baseShootingTimer = shootingTimer;
        }

        // Update is called once per frame
        void Update()
        {
            ShootingDelayTimer();
            BulletManager();
        }

        void BulletManager()
        {
            if (inputDetected || autoShoot)
            {
                inputDetected = false;
                if (canShoot)
                {
                    Debug.Log("Shooting");

                    if (currentBulletCount < maxBulletCount)
                    {
                        GameObject bullet = Instantiate(bulletTypes[0], gameObject.transform.position, Quaternion.identity);
                        ammo.Add(bullet);

                        bullet.transform.right = transform.right.normalized;

                        currentBulletCount++;
                        Debug.Log("rotationLocal " + gameObject.transform.localRotation);
                        Debug.Log("rotation " + gameObject.transform.rotation);
                        Debug.Log("bulletRotation " + bullet.transform.rotation);
                    }
                    else
                    {
                        foreach (GameObject bullet in ammo)
                        {
                            if (bullet.activeSelf == false)
                            {
                                //bullet.transform.position = gameObject.transform.position;
                                //bullet.transform.localRotation = gameObject.transform.rotation;
                            }
                        }
                    }
                    ResetShootingDelayTimer();
                }
            }

            // Bullet Movement
            if (ammo.Count > 0)
            {
                foreach (GameObject bullet in ammo)
                {
                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
                }
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

        public void ResetShootingDelayTimer()
        {
            shootingTimer = baseShootingTimer;
        }
    }
}
