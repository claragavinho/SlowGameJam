using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{

    public GameObject branchprefab;
    public float branchSpawnInterval = 2f;
    public float branchSpawnHeight = 6.5f;
    public float leftX = -2f;
    public float rightX = 2f;

    private float LastBranchY;
    private bool spawnLeft = true;

    private void Start()
    {
        SpawnInitialBranch();
    }
    private void Update()
    {
        if (Camera.main.transform.position.y + branchSpawnHeight > LastBranchY)
        {
            SpawnBranch();
        }
    }
    void SpawnInitialBranch()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnBranch();
        }
    }

    void SpawnBranch()
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

        Vector3 SpawnPosition = new Vector3(xpos, LastBranchY + branchSpawnHeight, 0);
        Instantiate(branchprefab, SpawnPosition, Quaternion.identity);
        LastBranchY += branchSpawnInterval;

        // Alternate between left and right
        spawnLeft = !spawnLeft;
    }
}