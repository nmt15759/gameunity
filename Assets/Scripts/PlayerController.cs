using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Lấy input từng hướng (dùng GetKey để chính xác, hỗ trợ nhiều phím)
        float x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);

        moveInput = new Vector2(x, y).normalized;

        // Cập nhật thông tin cho Animator
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetBool("isRun", moveInput.magnitude > 0);

        // Di chuyển nhân vật
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
