using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private SpriteRenderer PlayerSp;
    private Animator PlayerAn;
    [SerializeField] private float jumpforce;
    [SerializeField] private float Speed;

    [SerializeField] private LayerMask platformLayerMask;
    private bool isGrounded = true;
    BoxCollider2D playerCollider;
    float heightTest = .01f;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerSp = GetComponent<SpriteRenderer>();
        PlayerAn = GetComponent<Animator>();

        playerCollider = GetComponent<BoxCollider2D>();
        //layerMaskGround = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        float MoveInput = Input.GetAxis("Horizontal");
        Move(MoveInput);

        if (MoveInput > 0) //sprite flip hack
            PlayerSp.flipX = true;
        else
            PlayerSp.flipX = false;
    }
    private void Jump()
    {
        Debug.Log("Jump");
        PlayerRb.velocity = Vector2.zero; //resets velocity to 0 before jumping
        PlayerRb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        IsGrounded();
        //isGrounded = false;// stops from double jumping 
        PlayerAn.enabled = true;
        AudioManager.Instance.PlayJumpSound();
    }
    private void Move(float MoveInput)// Player Movement
    {
        Debug.Log("Move");
        PlayerRb.velocity = new Vector2(MoveInput * Speed, PlayerRb.velocity.y);
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Branch"))
    //    {
    //        Debug.Log("Collision Detected");
    //        IsGrounded();
    //        PlayerAn.enabled = false;
    //        AudioManager.Instance.PlayLandSound();
    //    }
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("On Ground");
    //        IsGrounded();
    //        PlayerAn.enabled = false;
    //        AudioManager.Instance.PlayLandSound();
    //    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + heightTest, platformLayerMask);
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerCollider.bounds.center, Vector2.down * (playerCollider.bounds.extents.y + heightTest));
        //bool isGrounded = hit.collider != null;
        return isGrounded;
    }
}
