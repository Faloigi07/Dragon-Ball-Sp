using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Move : MonoBehaviour{

    Rigidbody2D body;
    Animator anim;
    //Variabili Aggiornabili
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float JumpForce = 0.0f;

    bool IsJumping = false;  

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * moveSpeed * h, body.velocity.y);

        body.velocity = velocity;

        if(velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("IsMoving", Mathf.Abs(h));
    }

    void Jumping()
    {
        if (IsJumping)
        {
            if(body.velocity.y == 0)
            {
                IsJumping = false;
                anim.SetBool("IsJumping", false);
            }
        }
        else
        {
            if(Input.GetAxis("Jump") > 0)
            {
                body.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                IsJumping = true;
                anim.SetBool("IsJumping", true);
            }
        }
    }
}
