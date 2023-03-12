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
            rb = GetComponent<Rigidbody2D>();
            enemyStats = this.gameObject.GetComponent<EnemyStats>();
            _player = GameObject.Find("Player").GetComponent<PlayerController>();
            spawning = true;
        }

        protected override void FixedUpdate()
        {
            if (spawning) SpawnIn();
            else ChasePlayer();
        }
    }
}
