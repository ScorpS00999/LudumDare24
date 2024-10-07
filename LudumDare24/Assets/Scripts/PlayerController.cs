using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Attribute : ")]
    [SerializeField] private float mSpeed = 0.1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float bounceForce = 5f;
    [SerializeField] private int maxJump = 1;
    [SerializeField] private int attackPoints = 25;
    private Animator m_Animator;

    private int JumpNumber = 0;

    [Header("Platform Creation:")]
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float platformOffset = 1.5f;
    [SerializeField] private float platformLifetime = 5f;

    private Vector2 mMoveVector;
    private bool jumpPressed = false;
    [Header("Layers : ")]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask mushroomLayer;
    [SerializeField] public LayerMask ennemyLayer;
    [SerializeField] public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded = true;
    private bool hasAttackedEnnemy = false;
    private bool createPlatform = false;
    private bool canCreatePlatform = true;

    private Rigidbody2D rgbd2D;
    private PlayerControls controls;

    [Header("Interaction UI")]
    [SerializeField] public TextMeshProUGUI interactionText;
    private bool isInRange = false;


    private CharacterData currentCharacterData;
    [SerializeField] private CharacterDisplay characterDisplay;

    private string collidedObjectName;

    [SerializeField] public GameObject mushroom;

    #region Initialization
    private void Awake()
    {
        controls = new PlayerControls();

        // Find the character object
        rgbd2D = GetComponent<Rigidbody2D>();
        interactionText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    #endregion

    private void FixedUpdate()
    {
        Move();

        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (jumpPressed && isGrounded)
        {
           Jump();
        }
        if (isGrounded)
        {
            JumpNumber = 0;
            hasAttackedEnnemy = false;
            m_Animator.SetBool("isJumpin", false);

        }
        Bounce();
        JumpOnEnnemy();
        CreatePlatform();
    }

    #region Input Reading
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
                m_Animator.SetBool("isJumpin", true);
            }
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }
    public void ReadPlatformCreationInput(InputAction.CallbackContext context)
    {
        // Read pletform creation input (pressed or released)
        if (context.performed)
        {
            createPlatform = true;
            m_Animator.SetBool("hasBeenCreated", true);
        }
        else if (context.canceled)
        {
            createPlatform = false;
        }
    }
    public void ReadInteractInput(InputAction.CallbackContext context)
    {
        // Lire l'input d'interaction (pressé ou relâché)
        if (context.performed && isInRange) // Check if player is in range
        {
            if (collidedObjectName != null) {
                characterDisplay.TriggerDialog();
                interactionText.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("CharacterData is empty");
            }
            
        }
    }
    #endregion

    public void Move()
    {
        // Find the direction
        Vector2 direction = new Vector2(mMoveVector.x, mMoveVector.y).normalized;

        if (direction.magnitude >= 1.0f)
        {
            rgbd2D.position += direction * mSpeed;
            m_Animator.SetBool("isWalkin", true);
        }
        else
        {
            m_Animator.SetBool("isWalkin", false);
        }
    }

    public void Jump()
    {
        // Apply jump force if grounded
        rgbd2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpPressed = false;
        m_Animator.SetBool("isJumpin", false);
    }

    public void Bounce()
    {
        bool shouldBounce = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, mushroomLayer);

        if (shouldBounce)
        {
            Animator mushroomAnimator = mushroom.GetComponent<Animator>();

            if (mushroomAnimator != null)
            {
                // Activer l'animation du rebond sur le champignon
                mushroomAnimator.SetBool("hasBounce", true);

                // Réinitialise la vitesse verticale à 0 avant d'ajouter la force du rebond
                rgbd2D.velocity = new Vector2(rgbd2D.velocity.x, 0f);
                rgbd2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

                mushroomAnimator.SetBool("hasBounce", false);
            }
            else
            {
                Debug.LogWarning("Animator non trouvé sur l'objet Mushroom");
            }
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
                Debug.Log("Ennemy Attacked! " + attackPoints + " points de vie retirés.");
                hasAttackedEnnemy = true;
            }
        }
    }
    public void CreatePlatform()
    {
        if (createPlatform && platformPrefab != null && canCreatePlatform)
        {
            // Create a platform above player's head
            Vector3 platformPosition = new Vector3(transform.position.x, transform.position.y + platformOffset, transform.position.z);

            GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            StartCoroutine(DestroyPlatformAfterTime(newPlatform));

            // Désactiver la création de plateforme après l'action
            createPlatform = false;
            canCreatePlatform = false;
            m_Animator.SetBool("hasBeenCreated", false);

        }
    }
    private IEnumerator DestroyPlatformAfterTime(GameObject platform)
    {
        // Attendre pendant platformLifetime secondes
        yield return new WaitForSeconds(platformLifetime);

        // Détruire la plateforme
        Destroy(platform);
        canCreatePlatform = true;
    }
    // Gérer la détection des objets interactifs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interactiv"))
        {
            isInRange = true;

            collidedObjectName = collision.gameObject.name;

            characterDisplay = collision.gameObject.GetComponent<CharacterDisplay>();

            characterDisplay.EnleverDialogue();

            Debug.Log(collidedObjectName);
            string interactKey = InputControlPath.ToHumanReadableString(controls.Player.Interact.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            string interactKey2 = InputControlPath.ToHumanReadableString(controls.Player.Interact.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            interactionText.text = $"Press {interactKey} or {interactKey2} to interact";
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interactiv"))
        {
            isInRange = false;
            interactionText.gameObject.SetActive(false);
            collidedObjectName = null;
        }
    }
}