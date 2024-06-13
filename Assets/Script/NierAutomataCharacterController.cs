using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NierAutomataCharacterController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float rotationSpeed = 720f;

    public float turnSmoothTime = 0.1f; // ƽ��ת��ʱ��
    private float turnSmoothVelocity;

    private Rigidbody rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Transform cam;

    private float originalJumpHeight;
    private bool canMove = true; // ���ڿ�������Ƿ�����ƶ�

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        cam = Camera.main.transform;
        originalJumpHeight = jumpHeight; // ��¼ԭʼ��Ծ�߶�
        Debug.Log("NierAutomataCharacterController started.");
    }

    void Update()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, -2f, rb.velocity.z);
        }

        // ��Ծ
        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * -2f * gravity), rb.velocity.z);
            Debug.Log("Player jumped with velocity: " + rb.velocity.y);
        }

        // Ӧ������
        if (!isGrounded)
        {
            rb.AddForce(Vector3.up * gravity * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    void FixedUpdate()
    {
        if (!canMove) return; // ��������ƶ���ֱ�ӷ���

        // �����ƶ�����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // ����Ŀ��ǶȺ���ת
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // �����ƶ�����
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(rb.position + moveDir * walkSpeed * Time.fixedDeltaTime);
        }
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("NierAutomataCharacterController velocity reset.");
    }

    public void SetEnhancedJump(float newJumpHeight)
    {
        jumpHeight = newJumpHeight;
        Debug.Log("Jump height enhanced to: " + jumpHeight);
    }

    public void ResetJumpHeight()
    {
        jumpHeight = originalJumpHeight;
        Debug.Log("Jump height reset to: " + jumpHeight);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
        if (!value) ResetVelocity(); // �����ֹ�ƶ��������ٶ�
        Debug.Log("Player can move: " + canMove);
    }
}
