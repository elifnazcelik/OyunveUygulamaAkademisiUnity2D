using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.0f; // We need to define it beforehand since we'll be using it.
    private Rigidbody2D r2d; //We should use Rigidbody and Animator in the script since it affects both the animation and the movement.
    private Animator animator;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        animator = GetComponent<Animator>(); //caching anim
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            speed = 1.0f;
        }
        else
        {
            speed = 0.0f;
        }

        animator.SetFloat(name: "speed", speed); //In the Animator, we define the "speed" parameter which we use in the script.
        r2d.velocity = new Vector2(speed, 0.0f);
    }
}
