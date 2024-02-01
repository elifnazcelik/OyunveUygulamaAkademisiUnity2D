using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public float speed = 0.0f; // We need to define it beforehand since we'll be using it.
    private Rigidbody2D r2d; //We should use Rigidbody and Animator in the script since it affects both the animation and the movement.
    private Animator animator;
    Vector3 charPosition; //to store position data
    [SerializeField] private GameObject camera; //We can see from inspector and add game object

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        animator = GetComponent<Animator>(); //caching anim
        charPosition = transform.position; //current character position
    }

    private void FixedUpdate() //physics, 50 fps(It is explained in detail in the "time calculation" section of the lecture notes.)
    {
       // r2d.velocity = new Vector2(speed, 0.0f); //Unity Pyhsics
    }

    private void Update() // per frame
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            speed = 1.0f;
        }
        else
        {
            speed = 0.0f;
        }
        charPosition = new Vector3(charPosition.x + (speed * Time.deltaTime), charPosition.y);   //The character's position changing based on velocity with our pyhsic calculations
        transform.position = charPosition; //We set the calculated new position as the character's position.
        animator.SetFloat(name: "speed", speed); //In the Animator, we define the "speed" parameter which we use in the script.
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(charPosition.x, charPosition.y, charPosition.z - 1.0f); ///The camera automatically follows the character. The camera starts one meter behind.
    }
}
