using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mSpeed = 0.1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private int maxJump = 1;
    [SerializeField] private int attackPoints = 25;

    private int JumpNumber = 0;

    private Vector2 mMoveVector;
    private bool jumpPressed = false;

    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask mushroomLayer;
    [SerializeField] public LayerMask ennemyLayer;
    [SerializeField] public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded = true;
    private bool hasAttackedEnnemy = false;

    private Rigidbody2D rgbd2D;


    #region Initialization
    private void Awake()
    {
        // Find the character object
        Transform childObject = transform.Find("scope");
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    #endregion
    private void FixedUpdate()
    {
        Move();

        if (jumpPressed && isGrounded)
        {
           Jump();
        }
        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded )
        {
            JumpNumber = 0;
            hasAttackedEnnemy = false;
        }
        Bounce();
        JumpOnEnnemy();
    }

    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        mMoveVector = context.ReadValue<Vector2>();
    }

    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        // Read jump input (pressed or released)
        if (context.performed)
        {
            if (JumpNumber < maxJump)
            {
                jumpPressed = true;
                JumpNumber += 1;
            }
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }
    public void Move()
    {
        // Find the direction
        Vector2 direction = new Vector2(mMoveVector.x, mMoveVector.y).normalized;

        if (direction.magnitude >= 1.0f)
        {
            rgbd2D.position += direction * mSpeed;
        }
    }

    public void Jump()
    {
        // Apply jump force if grounded
        rgbd2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpPressed = false; 
    }

    public void Bounce()
    {
        bool shouldBounce = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, mushroomLayer);

        if (shouldBounce)
        {
            rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0f);
            rgbd2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }

    public void JumpOnEnnemy()
    {
        if (hasAttackedEnnemy) return;

        Collider2D ennemyHit = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ennemyLayer);

        if (ennemyHit != null)
        {
            EnnemyController ennemy = ennemyHit.GetComponent<EnnemyController>();

            if (ennemy != null)
            {
                ennemy.TakeDamage(attackPoints);
                rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0f);
                rgbd2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                Debug.Log("Ennemy Attacked! " + attackPoints + " points de vie retir�s.");
                hasAttackedEnnemy = true;
            }
        }
    }
}