using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class BlockEnemy : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }
}
