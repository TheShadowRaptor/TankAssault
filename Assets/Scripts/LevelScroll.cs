using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class LevelScroll : MonoBehaviour
    {
        //Scripts
        public GroundGeneration _groundGeneration;

        // Objects
        GameObject camObj;

        // Components
        Camera cam;
        SpriteRenderer spriteRenderer;

        private void FixedUpdate()
        {
            // Find Camera
            if (cam == null)
            {
                camObj = GameObject.Find("MainCamera");
                cam = camObj.GetComponent<Camera>();
            }

            ScrollBlocks();
        }

        void ScrollBlocks()
        {
            // Determins CameraBounds
            float camBounds = cam.orthographicSize * 2;
            //==========================================

            foreach (GameObject block in _groundGeneration.groundBlocks)
            {
                Vector3 pos = block.transform.position;

                if (pos.x < camBounds + 2) { pos.x += 1 * Time.deltaTime; }
                else pos.x = -camBounds - 2;
            
                block.transform.position = pos;
            }
        }

        bool IsBlockVisable(GameObject block)
        {
            spriteRenderer = block.GetComponent<SpriteRenderer>();
            if (spriteRenderer.isVisible == false) return false;

            return true;
        }
    }
}
