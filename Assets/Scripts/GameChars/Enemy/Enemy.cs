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

        protected virtual void FixedUpdate()
        {

        }

        protected void HandleTurretTurning()
        {
            if (enemyTurret == null) return;
            Vector3 direction = _player.transform.position - enemyTurret.transform.position;
            enemyTurret.transform.up = direction.normalized;
            enemyTurret.transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 15 * Time.deltaTime);
            enemyTurret.transform.Rotate(new Vector3(0f, 0f, 180f)); // Forces object to be fired in the direction of the object's local "forward" vector
        }
        protected void ChasePlayer()
        {
            Debug.Log("Chaser");
            //Move
            rb.velocity = transform.right * enemyStats.MovementSpeed * Time.deltaTime;

            Vector3 playerPos = _player.transform.position;
            Vector3 chaseLerp = Vector3.Lerp(transform.right, playerPos - transform.position, enemyStats.TurnSpeed * Time.deltaTime);
            transform.right = chaseLerp;
        }

        protected void SpawnIn()
        {
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
                other.gameObject.SetActive(false);
            }
        }
    }
}
