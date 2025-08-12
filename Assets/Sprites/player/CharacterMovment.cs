using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Timeline;
using UnityEngine.InputSystem;

public class CharacterMovment : MonoBehaviour
{
    private SpriteRenderer ch_SpriteRender;
    private BoxCollider2D ch_Collider;
    private Animator ch_Animator;
    private Rigidbody2D ch_Body;


    [SerializeField] private BoxCollider2D ch_Feet_Collider;


    [SerializeField] private int Health = 100;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jump_force = 12f;

    private float movmentX;
    private float movmentY;
    private String IDLE_ANIMATION = "Idle";
    private String RUN_ANIMATION = "Run";
    private String JUMP_ANIMATION = "Jump";
    private String FALL_ANIMATION = "Fall";

    private String HURT_ANIMATION = "Hurt";

    private String GROUND_TAG = "Ground";
    private bool isGrounded = true;

    void Start()
    {

    }

    private void Awake()
    {
        ch_SpriteRender = GetComponent<SpriteRenderer>();
        ch_Collider = GetComponent<BoxCollider2D>();
        ch_Animator = GetComponent<Animator>();
        ch_Body = GetComponent<Rigidbody2D>();
        ch_Body.freezeRotation = true;

    }
    void Update()
    {
        Character_Movment();
        Character_Animation();
          
      
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Character_Movment()
    {
        movmentX = Input.GetAxis("Horizontal");
      
      ch_Body.velocity=new Vector2(movmentX * speed,ch_Body.velocity.y);
    }
    private void Character_Animation()
    {

        //run animation
        if (movmentX < 0)
        {
            ch_Animator.SetBool(RUN_ANIMATION, true);
            ch_SpriteRender.flipX = true;
        }
        else if (movmentX > 0)
        {
            ch_Animator.SetBool(RUN_ANIMATION, true);
            ch_SpriteRender.flipX = false;
        }
        else
        {
            ch_Animator.SetBool(RUN_ANIMATION, false);
        }

        //fall and jump animations
        if (ch_Body.velocity.y > 0 && !isGrounded)
        {
            ch_Animator.SetBool(JUMP_ANIMATION, true);
            ch_Animator.SetBool(FALL_ANIMATION, false);

        }
        else if (ch_Body.velocity.y < 0 && !isGrounded)
        {
            ch_Animator.SetBool(FALL_ANIMATION, true);
            ch_Animator.SetBool(JUMP_ANIMATION, false);

        }
        else
        {
            ch_Animator.SetBool(FALL_ANIMATION, false);
            ch_Animator.SetBool(JUMP_ANIMATION, false);
        }


    }
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space)  && isGrounded)
        {
      ch_Body.velocity=new Vector2(ch_Body.velocity.x,jump_force);

            isGrounded = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)&&collision.otherCollider == ch_Feet_Collider)
        {
            isGrounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)&&collision.otherCollider == ch_Feet_Collider)
        {
            isGrounded = false;            
        }
    }
}
