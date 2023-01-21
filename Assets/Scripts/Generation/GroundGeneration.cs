using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class GroundGeneration : MonoBehaviour
    {
        // Feilds
        private List<GameObject> groundBlocks = new List<GameObject>();

        // Properties
        public List<GameObject> GroundBlocks { get => groundBlocks; }

        // GameObjects
        [Header("Prefab")]
        public GameObject groundBlock;

        GameObject camObj;

        // Components
        Camera cam;

        private void Start()
        {
            camObj = GameObject.Find("MainCamera");
            cam = camObj.GetComponent<Camera>();

            GenerateBlocks();
        }

        // Methods
        public void GenerateBlocks()
        {
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
            Debug.Log(camBounds);
        }
    }
}
