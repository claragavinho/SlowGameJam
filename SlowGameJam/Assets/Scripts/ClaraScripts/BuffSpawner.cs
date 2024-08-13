using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] buffprefabs;
    private bool spawnLeft = true;

    public float spawnInterval = 2f;
    public float spawnHeight = 6.5f;
    public float leftX = -2f;
    public float rightX = 2f;

    public float LastBuffY;

    private bool canSpawn;
    private void Update()
    {
        if (Camera.main.transform.position.y + spawnHeight > LastBuffY)
        {
            canSpawn = Random.Range(0,100) < 10;

            BuffSpawnCheck();
            SpawnBuff(); 
        }
    }
    public void SpawnBuff()
    {
        LastBuffY += spawnInterval;
        spawnLeft = !spawnLeft;
    }
    public void BuffSpawnCheck()
    {
        float xpos;
        if (spawnLeft)
        {
            xpos = leftX;
        }
        else
        {
            xpos = rightX;
        }
        Vector3 buffSpawnPosition = new Vector3(xpos, LastBuffY + spawnHeight, 0);

        if (canSpawn)
            Instantiate(buffprefabs[0], buffSpawnPosition, Quaternion.identity);
    }
}
