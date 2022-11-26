using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D body;
    private TrailRenderer tr;
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float castingLength = 0.9f;
    [SerializeField] private bool isJumped;
    public bool canMove = false;

    [Header("Dashing")]
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    [Header("State")]
    [SerializeField] private bool dead = false;
    [SerializeField] private bool won = false;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing || !canMove) { return; }

        if (Input.GetButtonDown("Jump") && isJumped) Jump();
        if (Input.GetKeyDown(KeyCode.Mouse1) && canDash) StartCoroutine(Dash());
    }

    private void FixedUpdate()
    {
        if (isDashing || !canMove) { return; }

        body.velocity = new Vector2(Vector2.right.x * speed, body.velocity.y);
        CheckCollisions();
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, 0f);
        body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    private void CheckCollisions()
    {
        isJumped = Physics2D.Raycast(transform.position * castingLength,
                                     Vector2.down, castingLength, groundLayer);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Obstacle")
       {
            dead = true;
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            won = true;
        }
    }

    public bool Dead
    {
        get
        {
            return dead;
        }
        set
        {
            dead = value;
        }
    }

    public bool Won
    {
        get
        {
            return won;
        }
        set
        {
            won = value;
        }
    }
}
