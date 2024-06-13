using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 5f; // 角色移动速度
    public float jumpForce = 10f; // 角色跳跃力度
    public Transform groundCheck; // 用于检测地面
    public LayerMask groundLayer; // 地面层
    public float groundCheckDistance = 0.2f; // 地面检测距离

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 水平移动
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // 检查是否在地面上
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

        // 跳跃
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        // 绘制地面检测范围
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
