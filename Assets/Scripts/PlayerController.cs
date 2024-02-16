using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animate;
    private bool facingRight = true;
    private float moveHorizontal;
    private float moveSpeed =5f;

    void Start()
    {
        rb2D= gameObject.GetComponent<Rigidbody2D>();
        animate =gameObject.GetComponent<Animator> ();
    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        
        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    void FixedUpdate()
    {
        MoveCharacter(moveHorizontal);
    }
    void MoveCharacter(float horizontalMovement)
    {
        Vector2 velocity = rb2D.velocity;
        velocity.x = horizontalMovement * moveSpeed;
        rb2D.velocity = velocity;
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
