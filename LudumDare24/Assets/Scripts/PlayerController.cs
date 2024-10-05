using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mSpeed = 0.1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJump = 1;

    private int JumpNumber = 0;

    private Vector2 mMoveVector;
    private bool jumpPressed = false;
    private CharacterController mCharacter;
    [SerializeField]  public LayerMask groundLayer;
    [SerializeField]  public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded = true;

    private Rigidbody2D rgbd2D;


    #region Initialization
    private void Awake()
    {
        // Find the character object
        Transform childObject = transform.Find("scope");
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        Destroy(mCharacter);
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
        }
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
                Debug.Log(JumpNumber);
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
}