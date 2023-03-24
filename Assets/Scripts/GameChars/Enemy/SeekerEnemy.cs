using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class SeekerEnemy : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody2D>();
            enemyStats = this.gameObject.GetComponent<EnemyStats>();

            spawnPoint = transform.position;
            hitEffectTimeReset = hitEffectTime;

            _player = MasterSingleton.MS.playerController;
            spawning = true;
        }

        protected override void FixedUpdate()
        {
            if (spawning) SpawnIn();
            else rb.velocity = Vector3.zero;
            HandleTurretTurning();
        }
    }
}
