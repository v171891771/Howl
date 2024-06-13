using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 5f; // ��ɫ�ƶ��ٶ�
    public float jumpForce = 10f; // ��ɫ��Ծ����
    public Transform groundCheck; // ���ڼ�����
    public LayerMask groundLayer; // �����
    public float groundCheckDistance = 0.2f; // ���������

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ˮƽ�ƶ�
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

        // ����Ƿ��ڵ�����
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

        // ��Ծ
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        // ���Ƶ����ⷶΧ
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }
}
