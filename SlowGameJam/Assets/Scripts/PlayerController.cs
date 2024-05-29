using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    //[SerializeField] private float _height;

    private PInputManager _playerInput;

    private Rigidbody2D _rigidbody;
    private Vector2 dir;

    void Start()
    {
       _rigidbody = GetComponent<Rigidbody2D>(); 
       _playerInput = GetComponent<PInputManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(_playerInput.Movement);
    }

    public void Movement(Vector2 direction)
    {
        dir = direction;
        _rigidbody.velocity += dir * _speed * Time.fixedDeltaTime;
        
        if (direction == Vector2.zero) 
        { 
            _rigidbody.velocity = Vector2.zero;
        }
    }
    public void Jump()
    {
        Debug.Log("Jump");
    }
}
