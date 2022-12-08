using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class GroundGeneration : MonoBehaviour
    {
        public GameObject groundBlock;
        public List<GameObject> groundBlocks = new List<GameObject>();

        GameObject camObj;
        Camera cam;

        // Start is called before the first frame update
        void Start()
        {
            if (cam == null)
            {
                camObj = GameObject.Find("MainCamera");
                cam = camObj.GetComponent<Camera>();
            }

            float camBounds = cam.orthographicSize * 2; // Gets half the camera size

            for (int i = -2; i < camBounds * 2 + 2; i++) // Doubled the value for blocks to reach screen to screen. 
            {                                            // -2 & +2 are so the blocks spawn outside the screen as well
                GameObject block = Instantiate(groundBlock);
                groundBlocks.Add(block);

            
                // Places the blocks
                Vector3 pos = block.transform.position;
                pos.x = -camBounds + i;
                pos.y = -camBounds / 2;
                block.transform.position = pos;
            }
        }
    }
}
