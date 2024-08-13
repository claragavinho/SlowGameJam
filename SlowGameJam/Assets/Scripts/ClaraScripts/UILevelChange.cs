using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILevelChange : MonoBehaviour
{
    [SerializeField]
    BranchSpawner branchSpawner;

    [SerializeField]
    TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLevel(Levels newLevel)
    {
        if (newLevel == Levels.Level1)
        {
            levelText.text = "Level 1";
        }
        else if (newLevel == Levels.Level2) 
        {
            levelText.text = "Level 2";
        }
        else if (newLevel == Levels.Level3)
        {
            levelText.text = "Level 3";
        }
        else
        {
            levelText.text = "No level";
        }
    }
}
