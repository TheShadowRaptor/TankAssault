using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class LevelScroll : MonoBehaviour
    {
        // GameObject
        GameObject camObj;

        //Scripts
        public GroundGeneration _groundGeneration;

        // Components
        SpriteRenderer spriteRenderer;
        Camera cam;

        // Methods
        private void Start()
        {
            camObj = GameObject.Find("MainCamera");
            cam = camObj.GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            ScrollBlocks();
        }

        void ScrollBlocks()
        {
            // Determins CameraBounds
            float camBounds = cam.orthographicSize * 2; // Gets half the camera size
            //==========================================

            foreach (GameObject block in _groundGeneration.GroundBlocks)
            {
                // Scroll blocks before reusing them at the beginning
                Vector3 pos = block.transform.position;

                if (pos.x < camBounds + 2) { pos.x += 1 * Time.deltaTime; }
                else pos.x = -camBounds - 2;
            
                block.transform.position = pos;
            }
        }
    }
}
