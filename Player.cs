using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        Vector2 rayOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, castDistance, ground);
        Debug.DrawRay(rayOrigin, Vector2.down * castDistance, Color.red);

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
        movement = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        rb.AddForce(movement);

        Vector2 velocity = rb.velocity;
        velocity.x *= (1.0f - friction);
        rb.velocity = velocity;
        if(Input.GetKey(KeyCode.W))
        {
          if(Grounded == true)
                {
                    Jump = Vector2.up * JumpForce;
                    rb.AddForce(Jump, ForceMode2D.Impulse);
                }


            
        }
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
