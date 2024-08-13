using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

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
    private Levels CurrentLevel;
    //public int level;
    private int maxSpawn;
    private int currentBranchHeight;

    GameObject spawnedBranch;
    Vector3 SpawnPosition;
    GameObject branchToSpawn;

    public UnityEvent<Levels> OnLevelChanged = new ();

    private void Start()
    {
        OnLevelChanged.Invoke(Levels.Level1);
        SpawnInitialBranch();
    }
    private void Update()
    {
        if (Camera.main.transform.position.y + branchSpawnHeight > LastBranchY)
        {
            SpawnBranch();
        }
        if (currentBranchHeight == branchesPerLevel[0] && CurrentLevel != Levels.Level2)
            OnLevelChanged.Invoke(Levels.Level2);
        //level = 2;
        else if (currentBranchHeight == branchesPerLevel[1] && CurrentLevel != Levels.Level3)
            OnLevelChanged.Invoke(Levels.Level3);
        //level = 3;
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
        SetspawnedBranch(branchToSpawn);
        //Instantiate(branchprefab, SpawnPosition, Quaternion.identity);
        LastBranchY += branchSpawnInterval;
        currentBranchHeight++; 

        // Alternate between left and right
        spawnLeft = !spawnLeft;
        if(spawnLeft && spawnedBranch != null) 
        spawnedBranch.GetComponent<SpriteRenderer>().flipX = true;
    }
    private void SetspawnedBranch(GameObject branchPrefabObj)
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

        SpawnPosition = new Vector3(xpos, LastBranchY + branchSpawnHeight, 0);

        spawnedBranch = Instantiate(branchPrefabObj, SpawnPosition, Quaternion.identity);
    }
    public void OnLevelChange(Levels newLevel)
    {
        switch (newLevel)
        {
            case Levels.Level1:
                branchToSpawn = branchprefabs[0];

                break;
            case Levels.Level2:
                branchToSpawn = branchprefabs[Random.Range(0, branchprefabs.Length)];

                break;
            case Levels.Level3:
                branchToSpawn = branchprefabs[Random.Range(0, branchprefabs.Length)];

                break;
            default:
                break;
        }
    }
}