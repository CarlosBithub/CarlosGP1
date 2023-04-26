using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    private Rigidbody2D rb;
    public bool faceright = true;
    private float moveDirection;
    private bool isJumping = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        if (moveDirection > 0 && !faceright)
        {
            flipcharacter();
        }
        else if (moveDirection < 0 && faceright)
        {
            flipcharacter();
        }
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(10f, jumpforce));
        }
        isJumping = false;
    }
    private void flipcharacter()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }

  
}
