using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class ChaserEnemy : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            spawnPoint = transform.position;
            rb = GetComponent<Rigidbody2D>();
            enemyStats = this.gameObject.GetComponent<EnemyStats>();
            _player = MasterSingleton.MS.player;
            spawning = true;
        }

        protected override void FixedUpdate()
        {
            if (spawning) SpawnIn();
            else ChasePlayer();
        }
    }
}
