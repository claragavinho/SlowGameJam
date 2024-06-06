using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField]private float offset =-3;
    private BranchSpawner branchSpawner;
    private void Start()
    {
        branchSpawner = FindObjectOfType<BranchSpawner>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,branchSpawner.LastBranchY+ offset,transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player_Destroyed");
            Destroy(other.gameObject);
            AudioManager.Instance.PlayDieSound();
        }
       
        if (other.CompareTag("Branch"))
        {
            Debug.Log("BranchDestroyed");
            Destroy(other.gameObject); 
        }
       
        
    }
}
