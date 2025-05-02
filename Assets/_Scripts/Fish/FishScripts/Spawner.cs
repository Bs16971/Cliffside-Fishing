using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject npcPrefab;

    public Vector3 spawnAreaSize = new Vector3(10f, 10f, 10f);
    public Transform spawnCenter;
    public float spawnInterval = 5f;

    public int maxNPCs = 10;

    private int currentNPCs = 0;

    private bool spawning = false;
    private Coroutine spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        
        // spawner = StartCoroutine(SpawnNPCs());
        
    }
    

    IEnumerator SpawnNPCs()
    {
        
        while (currentNPCs < maxNPCs)
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            Instantiate(npcPrefab, randomPosition, Quaternion.identity);
            currentNPCs++;
            // Debug.Log(currentNPCs + "currentNPCs");
            yield return new WaitForSeconds(spawnInterval);
            if (currentNPCs >= maxNPCs)
            {
                Debug.Log("Full!");
                yield break;
            }
        }
       
        
    }

   

    
    Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float randomY = Random.Range(10, spawnAreaSize.y / 2);
        float randomZ = Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2);

        Vector3 spawnPoint= new Vector3(randomX, randomY, randomZ);
        return spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNPCs <= maxNPCs && spawnInterval <= 0)
        {
           

            Vector3 randomPosition = GetRandomSpawnPosition();
            Instantiate(npcPrefab, randomPosition, Quaternion.identity);
            currentNPCs++;
            spawnInterval = 5;
            // Debug.Log(currentNPCs + "currentNPCs");

        }
        else
        {
            spawnInterval -= Time.deltaTime;
        }
    }
}
