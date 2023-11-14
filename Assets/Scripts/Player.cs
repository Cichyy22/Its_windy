using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grounded;

    public int AreBasketPicked;
    // Start is called before the first frame update
    void Start()
    {
        // AreBasketPicked = PlayerPrefs.GetInt("BasketPick");
    }
    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && grounded)
        {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
        }
         if(Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
        }
         if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
        }

    }
}
