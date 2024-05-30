using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D PlayerRb;
    [SerializeField] private float jumpforce;
    [SerializeField] private float Speed;

    private bool isGrounded = true;
    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
        {
            Jump();
        }
        float MoveInput = Input.GetAxis("Horizontal");
        Move(MoveInput);
    }
    private void Jump()
    {
        Debug.Log("Jump");
        PlayerRb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        isGrounded = false;// stops from double jumping 
    }
    private void Move(float MoveInput)// Player Movement
    {
        Debug.Log("Move");
        PlayerRb.velocity = new Vector2(MoveInput * Speed, PlayerRb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Branch"))
        {
            Debug.Log("Collision Detected");
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On Ground");
            isGrounded = true;
        }

    }
}
