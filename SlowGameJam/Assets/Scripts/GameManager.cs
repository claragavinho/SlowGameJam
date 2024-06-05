using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BranchSpawner branchSpawner;
    public Snake snake;
    // Start is called before the first frame update
    void Start()
    {
        branchSpawner = GetComponent<BranchSpawner>();
        snake = GetComponent<Snake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (branchSpawner.level == 3)
        {
            snake.SpawnSnake();
        }
    }

}
