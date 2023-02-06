using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class SceneryGeneration : MonoBehaviour
    {
        // Fields
        [Header("Prefab")]
        private List<GameObject> scenery = new List<GameObject>();      

        [Header("RandomizeValues")]
        public int emptyWeight;

        // Properties
        public List<GameObject> Scenery { get => scenery; }

        // GameObjects
        public List<GameObject> props = new List<GameObject>();

        // Scripts
        [Header("Scripts")]
        public GroundGeneration _groundGeneration;
        
        int sceneryNum;
        int randomProp;

        // Methods
        private void Start()
        {
            sceneryNum = 0;
        }

        void Update()
        {
            GenerateScenery();
            AddScenery();
            RemoveScenery();
        }

        void GenerateScenery()
        {
            // Generate Scenery Props on blocks
            randomProp = Random.Range(0, props.Count);
            if (sceneryNum != _groundGeneration.GroundBlocks.Count)
            {
                GameObject prop = Instantiate(props[randomProp]);
                scenery.Add(prop);

                Vector3 pos = prop.transform.position;
                pos.y = _groundGeneration.GroundBlocks[sceneryNum].transform.position.y + 1;
                pos.x = _groundGeneration.GroundBlocks[sceneryNum].transform.position.x;
                prop.transform.position = pos;
                prop.SetActive(false);

                sceneryNum++;
                Debug.Log("sceneryNum " + sceneryNum);
            }   
        }

        void AddScenery()
        {
            float camBounds = Camera.main.orthographicSize * 2; // Gets half the camera size
            int randomNum;
            randomNum = Random.Range(0, emptyWeight);
            for (int i = 0; i < scenery.Count - 1; i++)
            {
                if (randomNum == 0)
                {
                    if (scenery[i].transform.position.x < -camBounds - 1.5f)
                    {
                        // replace prop
                        //scenery[i] = props[randomProp];
                        scenery[i].SetActive(true);
                    }
                }
            }
        }

        void RemoveScenery()
        {
            float camBounds = Camera.main.orthographicSize * 2; // Gets half the camera size
            foreach (GameObject prop in scenery)
            {
                if (prop.transform.position.x > camBounds)
                {
                    prop.SetActive(false);
                }
            }
        }
    }
}

