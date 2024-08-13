using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public BranchSpawner branchSpawner;
    public Snake snake;
    private Levels CurrentLevel;

    private void OnEnable()
    {
        branchSpawner.OnLevelChanged.AddListener(ChangeLevel);
    }
    private void OnDisable()
    {
        branchSpawner.OnLevelChanged.RemoveListener(ChangeLevel);
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentLevel == Levels.Level3)
        {
            snake.SpawnSnake();
        }
    }
    public void ChangeLevel(Levels newLevel)
    {
        CurrentLevel = newLevel;
    }
}
public enum Levels 
{ 
    Level1, Level2, Level3
}
