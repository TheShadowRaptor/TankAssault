using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public abstract class Enemy : MonoBehaviour
    {
        protected PlayerController _player;

        [Header("GameObjects")]
        [SerializeField] protected GameObject enemyTurret;
        protected Vector3 spawnPoint;

        [Header("Scripts")]
        [SerializeField] protected EnemyStats enemyStats;

        [Header("Spawn Settings")]
        [SerializeField] protected float entryDistance;

        protected Rigidbody2D rb;

        protected bool spawning;

        // AudioSource
        protected AudioSource audioSource;

        protected float hitEffectTime = 0.2f;
        protected float hitEffectTimeReset;
        protected bool isHit;

        protected virtual void FixedUpdate()
        {
            
        }

        private void Update()
        {
            HitEffect();
        }

        protected void HandleTurretTurning()
        {
            if (enemyTurret == null) return;
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay
                || enemyStats.IsAlive == false)
            {
                rb.velocity = Vector3.zero;
                return;
            }

            Vector3 direction = _player.transform.position - enemyTurret.transform.position;
            enemyTurret.transform.up = direction.normalized;
            enemyTurret.transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 15 * Time.deltaTime);
            enemyTurret.transform.Rotate(new Vector3(0f, 0f, 180f)); // Forces object to be fired in the direction of the object's local "forward" vector
        }
        protected void ChasePlayer()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay
                || enemyStats.IsAlive == false)
            {
                rb.velocity = Vector3.zero;
                return;
            }

            //Move
            rb.velocity = transform.right * enemyStats.MovementSpeed * Time.deltaTime;

            Vector3 playerPos = _player.transform.position;
            Vector3 chaseLerp = Vector3.Lerp(transform.right, playerPos - transform.position, enemyStats.TurnSpeed * Time.deltaTime);
            transform.right = chaseLerp;
        }

        protected virtual void SpawnIn()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay
                || enemyStats.IsAlive == false)
            {
                rb.velocity = Vector3.zero;
                return;
            }

            rb.velocity = -transform.up * enemyStats.MovementSpeed * Time.deltaTime;

            float distance = Vector2.Distance(transform.position, spawnPoint);

            if (distance > entryDistance) spawning = false;
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                // Take Damage from player bullet
                //Debug.Log("hit");
                int damage = other.gameObject.GetComponent<Bullet>().bulletDamage;
                this.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                MasterSingleton.MS.audioManager.PlayAudio(audioSource, MasterSingleton.MS.audioManager.enemyHurt);
                isHit = true;
                other.gameObject.GetComponent<Bullet>().Deactivate();
            }
        }

        void HitEffect()
        {
            if (isHit)
            {
                hitEffectTime -= Time.deltaTime;
                this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                if (hitEffectTime <= 0)
                {
                    this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    hitEffectTime = hitEffectTimeReset;
                    hitEffectTime = 0;
                    isHit = false;
                }
            }
        }
    }
}
