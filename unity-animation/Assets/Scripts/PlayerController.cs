using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 25f;
    public float fallThreshold = -10f;
    private Rigidbody rb;
    private float moveX;
    private float moveZ;
    private Vector3 InitialPosition;
    private bool isGrounded;
    private Animator animator;
    private float speed = 0.0f;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isLanding = false;

    private void Awake()
    {
        InitialPosition = transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        CheckFall();

        float moveInput = Input.GetAxis("Vertical");
        speed = Mathf.Abs(moveInput);
        animator.SetFloat("Speed", speed);

        // Detect if player is falling
        if (rb.velocity.y < 0 && !isGrounded)
        {
            isFalling = true;
            animator.SetBool("IsFalling", true);
        }
        else
        {
            isFalling = false;
            animator.SetBool("IsFalling", false);
        }
    }

    void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0.0f, moveZ);
        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void CheckFall()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = InitialPosition;
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            isFalling = false;
            isLanding = true;  // Trigger Falling Flat Impact animation
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsLanding", true);  // Play the Falling Flat Impact animation
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isLanding = false;
            animator.SetBool("IsLanding", false);
        }
    }
}
