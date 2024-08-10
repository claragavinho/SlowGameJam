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
    private void Update()
    {
        if (Camera.main.transform.position.y + spawnHeight > LastBuffY)
        {
            SpawnBuff();
        }
    }
    public void SpawnBuff()
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
        Instantiate(buffprefabs[0], buffSpawnPosition, Quaternion.identity);

        LastBuffY += spawnInterval;
        spawnLeft = !spawnLeft;
    }
}
