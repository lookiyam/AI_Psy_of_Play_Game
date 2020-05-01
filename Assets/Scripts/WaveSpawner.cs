using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //to be shown in the unity inspecator 
    [System.Serializable]
    public class Wave
    {
        // which enemys can spawn in this wave
        public Enemy[] enemies;
        //how many can be in the wave
        public int count;
        //how long will it take to spawn a new enemy
        public float timeBetweenSpawns; 
    }
    //an array for the waves
    public Wave[] waves;
    //where enemy can spawn array
    public Transform[] spawnPoints;
    //how long it will take to start a new wave
    public float timeBetweenWaves;
    //to show current wave
    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    //to tell when the wave have fineshed spawning
    private bool finishedSpawning;
    // implement boss into arrey
    public GameObject boss;

    // where the boss should spawn
    public Transform bossSpawnPoint;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //to tell to start next wave
        StartCoroutine(StartNextWave(currentWaveIndex));
        
    }
    //function to wait until new wave to start 
    IEnumerator StartNextWave (int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));

        
    }
    IEnumerator SpawnWave (int index)
    {
        currentWave = waves[index];
        //to loop
        for (int i = 0; i < currentWave.count; i++)
        {
            //this code will be run as much as there is a count

            if (player == null)
            {
                //if player is dead the loop will stop so no more spawning 
                
                yield break;
                
            }
            
            //to select a random enemy from the array
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            //random spawn point
            Transform randomSpot = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            //to tell if the wave stoped
            if(i == currentWave.count -1)
            {
                finishedSpawning = true;
                
            }
                else
            {
                finishedSpawning = false;
                
            }

            
            //wait time between summons
            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
            
            
        }
    
    }
    
    private void Update()
    {
        
        //if finshed spawnning all the waves and there is no more eniems in the scene the playwer will succesffuly completed the waves
        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {   
            //to start a new wave
            finishedSpawning = false;
            
            //to check if there is another wave
            if (currentWaveIndex + 1 < waves.Length)
                {
                    //to continue to next wave
                    currentWaveIndex++;
                    StartCoroutine(StartNextWave(currentWaveIndex));
                    
                }
        else
            {
             //there is no move waves
            // instantiate the  boss at the end of the waves
            Instantiate (boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
            }
        }    
    }
}

