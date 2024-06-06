using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject[] BackGroundPrefab;
    private CameraControl cameraControl;
    private Vector3 Startpos;
    private GameObject SpawnedBackground;

    [SerializeField] private float offset = -1f;

    private void Start()
    {

       
         cameraControl = FindObjectOfType<CameraControl>();

        if (cameraControl == null )
        {
            Debug.Log("Camera Control not assigned");
        }
        Startpos = new Vector3(0, 6.45f, 0);
     SpawnedBackground=Instantiate(BackGroundPrefab[0], Startpos, BackGroundPrefab[0].transform.rotation);
    }
    private void Update()
    {
           SpawnedBackground.transform.position = new Vector3(transform.position.x, cameraControl.transform.position.y,transform.position.z);
    }
}
