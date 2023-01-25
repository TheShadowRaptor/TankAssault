using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject playerObj;
    // Update is called once per frame
    void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }

        playerObj.transform.position = this.gameObject.transform.position;

        if (playerObj.transform.position == this.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
