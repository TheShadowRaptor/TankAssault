using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ShootingController : MonoBehaviour
    {
        // Reset values
        float shootingTimerReset;
        float bulletSpeedReset;
        float shootingSpeedReset;
        int bulletDamageReset;

        [Header("Customization")]
        public GameObject bulletType;
        public CharacterStats characterStats;

        [Header("Bullets")]
        public List<GameObject> bullets = new List<GameObject>();
        public int currentBulletCount = 0;
        public int initialCapacity = 3;

        [Header("ShootingSettings")]
        public float shootingTimer;
        public float bulletSpeed;
        public float shootingSpeed;
        public int bulletDamage;
        protected bool canShoot;

        [HideInInspector] public bool inputDetected = false;

        public bool isEnemyTurret = false;

        // Switches
        [SerializeField] bool autoShoot = false;

        // AudioSource
        AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            shootingTimerReset = shootingTimer;
            bulletSpeedReset = bulletSpeed;
            shootingSpeedReset = shootingSpeed;
            bulletDamageReset = bulletDamage;
            BulletPoolInstantiation();
        }

        // Update is called once per frame
        void Update()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay) return;
            ShootingDelayTimer();
            BulletManager();
        }

        public void BulletPoolInstantiation()
        {
            Transform parentObject = GameObject.Find("BulletPool").transform; // Organizes bullets
            for (int i = 0; i < initialCapacity; i++)
            {
                GameObject bullet = Instantiate(bulletType, parentObject);
                bullets.Add(bullet);
                bullets[i].SetActive(false);
            }
        }

        void BulletManager()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay
                || characterStats.IsAlive == false)
            {
                return;
            }

            if (inputDetected || autoShoot)
            {
                inputDetected = false;
                if (canShoot)
                {
                    if (isEnemyTurret)
                    {
                        // Sound
                    }
                    else MasterSingleton.MS.audioManager.PlayAudio(audioSource, MasterSingleton.MS.audioManager.playerShoot);
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
                bullets[0].GetComponent<Bullet>().bulletDamage = bulletDamage;
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
            shootingTimer -= shootingSpeed * Time.deltaTime;
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
            shootingTimer = shootingTimerReset;
        }

        public void ResetStats()
        {
            bulletSpeed = bulletSpeedReset;
            shootingSpeed = shootingSpeedReset;
            bulletDamage = bulletDamageReset;
        }
    }
}

