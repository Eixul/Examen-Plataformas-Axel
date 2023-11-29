using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _playerSpeed = 5;
    [SerializeField] public float _jumpForce = 5;
    [SerializeField] public Animator _anim;
    private Rigidbody2D _rBody2D;
    public float _playerInputh;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }   
        _anim.SetBool("IsJumping", !GroundSensor._isGrounded);
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _playerInputh = Input.GetAxis("Horizontal");
        _rBody2D.velocity = new Vector2(_playerSpeed * _playerInputh, _rBody2D.velocity.y);

        if(_playerInputh < 0)
        {
            _anim.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if(_playerInputh > 0)
        {
            _anim.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else
        {
            _anim.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
