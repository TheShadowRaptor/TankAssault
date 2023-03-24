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

        public int waveCounter = 0;
        int numEnemiesPerWave = 1;
        float timeBetweenSpawns = 3f;
        int numOfWaves = 100;

        int randomlyChoosenEnemy;
        int randomlyChoosenSpawnPoint;
        float randomlyChoosenTimeBetweenSpawns;

        public int randomChaserHoardSpawn;
        int chaserHoardSize = 4;

        bool startOnce = true;

        // Update is called once per frame
        void Update()
        {
            if (MasterSingleton.MS.gameManager.currentGameState != GameManager.GameState.gameplay)
            {
                if (startOnce == false)
                {
                    startOnce = true;
                    StopAllCoroutines();
                    Debug.Log("Mainmenu");
                }
                return;
            }

            if (startOnce)
            {
                StartCoroutine(SpawEnemyWaves());
                startOnce = false;
            }
        }

        IEnumerator SpawEnemyWaves()
        {
            while (waveCounter < numOfWaves)
            {
                for (int i = 0; i < numEnemiesPerWave; i++)
                {
                    randomlyChoosenEnemy = Random.Range(0, enemyTypes.Count);
                    randomlyChoosenSpawnPoint = Random.Range(0, spawners.Count);
                    randomlyChoosenTimeBetweenSpawns = Random.Range(1, timeBetweenSpawns);
                    randomChaserHoardSpawn = Random.Range(0, 10);

                    if (randomChaserHoardSpawn == 9)
                    {
                        for (int j = 0; j < chaserHoardSize; j++)
                        {
                            randomlyChoosenSpawnPoint = Random.Range(0, spawners.Count);
                            Instantiate(enemyTypes[0], spawners[randomlyChoosenSpawnPoint].transform.position, spawners[randomlyChoosenSpawnPoint].transform.rotation);
                        }
                    }
                    else Instantiate(enemyTypes[randomlyChoosenEnemy], spawners[randomlyChoosenSpawnPoint].transform.position, spawners[randomlyChoosenSpawnPoint].transform.rotation);
                    yield return new WaitForSeconds(randomlyChoosenTimeBetweenSpawns);
                }
                numEnemiesPerWave += 2;
                waveCounter++;
                // adjust difficulty as needed
            }
            // end game or move on to next level
        }

        public void ResetStats()
        {
            waveCounter = 0;
            numEnemiesPerWave = 1;
            timeBetweenSpawns = 3f;
            numOfWaves = 100;
        }
    }
}
