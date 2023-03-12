using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TankAssault
{
    public class WaveManager : MonoBehaviour
    {
        public List<GameObject> spawners = new List<GameObject>();
        public List<GameObject> enemyTypes = new List<GameObject>();

        int numEnemiesPerWave = 1;
        float timeBetweenSpawns = 2;
        public int waveCounter = 0;
        int numOfWaves = 20;

        int randomlyChoosenEnemy;
        int randomlyChoosenSpawnPoint;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawEnemyWaves()); 
        }

        // Update is called once per frame
        void Update()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay) return;
        }

        IEnumerator SpawEnemyWaves()
        {
            while (waveCounter < numOfWaves)
            {
                for (int i = 0; i < numEnemiesPerWave; i++)
                {
                    randomlyChoosenEnemy = Random.Range(0, enemyTypes.Count);
                    randomlyChoosenSpawnPoint = Random.Range(0, spawners.Count);
                    Instantiate(enemyTypes[randomlyChoosenEnemy], spawners[randomlyChoosenSpawnPoint].transform.position, spawners[randomlyChoosenSpawnPoint].transform.rotation);
                    yield return new WaitForSeconds(timeBetweenSpawns);
                }
                numEnemiesPerWave += 2;
                waveCounter++;
                // adjust difficulty as needed
            }
            // end game or move on to next level
        }
    }
}
