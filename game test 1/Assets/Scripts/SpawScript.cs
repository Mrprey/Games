using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawScript : MonoBehaviour
{
    [System.Serializable]
    public class Wave{
        public GameObject[] enemies;
        public int enemyCount;
        public float spawntime;
    }

    public Wave[] waves;
    public Transform[] spawPoints;
    public float waveTime;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;
    private bool waveEnded;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (waveEnded == true 
        && GameObject.FindGameObjectsWithTag("Enemy").Length == 0
        && GameObject.FindGameObjectsWithTag("Boss").Length == 0 
        && GameObject.FindGameObjectsWithTag("EnemyRange").Length == 0){
            waveEnded = false;
            if(currentWaveIndex + 1 < waves.Length){
                currentWaveIndex ++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
        }
        else{
            Debug.Log("Ganhou!!!!!!!!");
        }
    }

    IEnumerator StartNextWave(int index){
        yield return new WaitForSeconds(waveTime);
        StartCoroutine(SpawnWaves(index));
    }

    IEnumerator SpawnWaves(int index){
        currentWave = waves[index];

        for(int i = 0; i < currentWave.enemyCount; i++){
            if(player == null){
                yield break;
            }

            Transform randomSpot = spawPoints[Random.Range(0, spawPoints.Length)];
            Instantiate(currentWave.enemies[Random.Range(0, currentWave.enemies.Length)], randomSpot.position, randomSpot.rotation);
        
            if (i == currentWave.enemyCount - 1){
                waveEnded = true;
            }
            else{
                waveEnded = false;
            }
            yield return new WaitForSeconds(currentWave.spawntime);
        }
    }
}
