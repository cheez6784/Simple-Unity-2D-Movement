using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // VERY IMPORTANT: Freeze the Z rotation of the Rigidbody2D under "Constraints" Otherwise The Force Will Mess Up The Player.
    
    // Variables, Vectors, and Refrences used
    private float input;
    public float speed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public float friction;
    private Vector2 Jump;
    public float JumpForce;
    public LayerMask ground;
    private bool Grounded;
    public float castDistance;
    public float maxVelocity = 10f;
    
    void Start()
    {
        
    }
    private void Update()
    {
        // This handles the raycast
        Vector2 rayOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, castDistance, ground);
        Debug.DrawRay(rayOrigin, Vector2.down * castDistance, Color.red);
        // Sets grounded to "true" if you are grounded
        if (hit.collider != null)
        {
            Grounded = true;
            
        }
        else
        {
            Grounded = false;
        }

    }
    
    void FixedUpdate()
    {
        // The simplest horizontal movement you can make
        movement = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        rb.AddForce(movement);
        // Adds friction to prevent you feeling like you are on ice
        Vector2 velocity = rb.velocity;
        velocity.x *= (1.0f - friction);
        rb.velocity = velocity;
        // Makes you jump if you press W
        if(Input.GetKey(KeyCode.W))
        {
          if(Grounded == true)
                {
                    // Just adding force to the bottom of the player
                    Jump = Vector2.up * JumpForce;
                    rb.AddForce(Jump, ForceMode2D.Impulse);
                }


            
        }
        // This clamps the velocity to "maxVelocity". Probably a horrible way to do this
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
