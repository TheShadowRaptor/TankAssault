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
        [Header("Scripts")]
        [SerializeField] protected EnemyStats enemyStats; 

        protected void FixedUpdate()
        {
            HandleTurretTurning();
        }

        protected void HandleTurretTurning()
        {
            Vector3 direction = _player.transform.position - enemyTurret.transform.position;
            enemyTurret.transform.up = direction.normalized;
            enemyTurret.transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 10 * Time.deltaTime);
            enemyTurret.transform.Rotate(new Vector3(0f, 0f, 180f)); // Forces object to be fired in the direction of the object's local "forward" vector
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
