using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class LevelScroll : MonoBehaviour
    {
        //Scripts
        public GroundGeneration _groundGeneration;
        public SceneryGeneration _sceneryGeneration;

        // Components
        SpriteRenderer spriteRenderer;

        // Methods
        private void Start()
        {

        }

        private void FixedUpdate()
        {
            ScrollBlocks();
            ScrollScenery();
        }

        void ScrollBlocks()
        {
            // Determins CameraBounds
            float camBounds = Camera.main.orthographicSize * 2; // Gets half the camera size
            //==========================================

            foreach (GameObject block in _groundGeneration.GroundBlocks)
            {
                // Scroll blocks before reusing them at the beginning
                Vector3 pos = block.transform.position;

                if (pos.x > -camBounds - 2) { pos.x -= 1 * Time.deltaTime; }
                else pos.x = camBounds + 2;
            
                block.transform.position = pos;
            }
        }

        void ScrollScenery()
        {
            // Determins CameraBounds
            float camBounds = Camera.main.orthographicSize * 2; // Gets half the camera size
            //==========================================

            foreach (GameObject prop in _sceneryGeneration.Scenery)
            {
                if (prop != null)
                {
                    // Scroll blocks before reusing them at the beginning
                    Vector3 pos = prop.transform.position;

                    if (pos.x > -camBounds - 2) { pos.x -= 1 * Time.deltaTime; }
                    else pos.x = camBounds + 2;

                    prop.transform.position = pos;
                }
            }
        }
    }
}
