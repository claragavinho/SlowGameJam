using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private SpriteRenderer PlayerSp;
    private Animator PlayerAn;
    [SerializeField] public float jumpforce;
    [SerializeField] private float Speed;
    [SerializeField] private float powerUpAmount;

    [SerializeField] private LayerMask platformLayerMask; 
    public float heightTest = 0.5f;
    public Vector2 boxSize;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        PlayerSp = GetComponent<SpriteRenderer>();
        PlayerAn = GetComponent<Animator>();
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
        //isGrounded = false;// stops from double jumping 
        PlayerAn.enabled = true;
        AudioManager.Instance.PlayJumpSound();
    }
    private void Move(float MoveInput)// Player Movement
    {
        Debug.Log("Move");
        PlayerRb.velocity = new Vector2(MoveInput * Speed, PlayerRb.velocity.y);
    }
    private bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,heightTest,platformLayerMask))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * heightTest, boxSize);
    }
    public void JumpPU()
    {
        jumpforce += powerUpAmount;
        GetComponent<SpriteRenderer>().color = Color.blue;
        StartCoroutine(ResetPowerUp());
    }
    private IEnumerator ResetPowerUp()
    {
        yield return new WaitForSeconds(5);
        jumpforce -= powerUpAmount;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
