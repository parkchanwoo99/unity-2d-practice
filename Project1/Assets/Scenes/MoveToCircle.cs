using UnityEngine;

public class MoveToCircle : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float fallLimitY = -10f;

    // 핵심 기능 변수 저장
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private Vector2 startPosition;

    // 바닥 체크용
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // 초기 위치 저장
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 입력 (A/D, ←/→)
        moveInput = Input.GetAxisRaw("Horizontal");

        // 점프 (Space)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();
        CheckGround();
        CheckFall();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        Debug.Log("isGrounded: " + isGrounded);
    }

    void CheckFall()
    {
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector2.zero;          // 속도 초기화
        transform.position = startPosition;  // 위치 되돌리기
    }

    // Scene 뷰에서 바닥 체크 범위 표시
    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
