using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public abstract class Enemy : MonoBehaviour
    {
        protected PlayerController _player;
        [SerializeField] protected GameObject enemyTurret;

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
            Debug.Log(enemyTurret.transform.up);
        }
    }
}
