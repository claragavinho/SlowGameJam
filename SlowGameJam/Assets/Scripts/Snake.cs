using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    GameObject snake;

    Vector3 startPos;
    Vector3 endPos;
    public Vector3 lerpDistance = new Vector3(0, 10, 0);

    // Start is called before the first frame update
    void Awake()
    {
       this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSnake()
    {
        this.gameObject.SetActive(true);

        startPos = snake.transform.position;
        endPos = startPos + lerpDistance;

        snake.transform.localPosition = Vector3.Lerp(startPos, endPos, Time.fixedDeltaTime);
        //snake = Instantiate(this.gameObject);
    }
    /*IEnumerator SnakeBehavior()
    {
        snakeAnim.Play("SnakeAnimation");
        yield return new WaitForSeconds(snakeAnimTime);
        startPos = snake.transform.position;    
        endPos = startPos + lerpDistance;

        snake.transform.localPosition = Vector3.Lerp(startPos, endPos, Time.fixedDeltaTime);
    }*/
}
