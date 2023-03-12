using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class PlayerSpawn : MonoBehaviour
    {
        GameObject playerObj;
        private void Start()
        {
            playerObj = MasterSingleton.MS.player.gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerObj != null)
            {
                playerObj.transform.position = this.gameObject.transform.position;
                if (playerObj.transform.position == this.transform.position)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
