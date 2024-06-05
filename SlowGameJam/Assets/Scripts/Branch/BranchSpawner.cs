using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{

    //public GameObject branchprefab;
    [SerializeField] int[] branchesPerLevel;
    public GameObject[] branchprefabs;
    public float branchSpawnInterval = 2f;
    public float branchSpawnHeight = 6.5f;
    public float leftX = -2f;
    public float rightX = 2f;

    public float LastBranchY;
    private bool spawnLeft = true;
    public int level;
    private int maxSpawn;

    private void Start()
    {
        level = 1;
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

        if (LastBranchY == branchesPerLevel[0])
            level = 2;
        else if (LastBranchY == branchesPerLevel[1])
            level = 3;

        GameObject currentBranch; 
        switch (level)
        {
            case 1:
              currentBranch =  Instantiate(branchprefabs[0], SpawnPosition, Quaternion.identity);
                
                break;
            case 2:
                currentBranch = Instantiate(branchprefabs[Random.Range(0, branchprefabs.Length)], SpawnPosition, Quaternion.identity);

                break;
            case 3:
                currentBranch = Instantiate(branchprefabs[Random.Range(0, branchprefabs.Length)], SpawnPosition, Quaternion.identity);
                //spawn snake
                break;
                default:
                currentBranch = null;
                break;

               
        }
        //Instantiate(branchprefab, SpawnPosition, Quaternion.identity);
        LastBranchY += branchSpawnInterval;               

        // Alternate between left and right
        spawnLeft = !spawnLeft;
        if(spawnLeft && currentBranch != null) 
        currentBranch.GetComponent<SpriteRenderer>().flipX = true;
    }
}