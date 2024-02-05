using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpForce=2.0f;
    public float speed=1.0f;
    public float moveDirection;

    private bool jump;
    private bool grounded = true;
    bool moving;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();//caching
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (rigidbody2D.velocity != Vector2.zero) //checking character moving or not
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rigidbody2D.velocity = new Vector2(speed* moveDirection, rigidbody2D.velocity.y);
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                spriteRenderer.flipX = true;
                animator.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                spriteRenderer.flipX = false;
                animator.SetFloat("speed", speed);
            }
        }else if (grounded == true)
        {
            moveDirection = 0.0f;
            animator.SetFloat("speed", 0.0f);
        }
    }
}
