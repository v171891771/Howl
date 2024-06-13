using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MarioOdysseyCharacterController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 7f;
    public float gravity = -9.81f;
    public float rotationSpeed = 720f;

    public float turnSmoothTime = 0.1f; // ƽ��ת��ʱ��
    private float turnSmoothVelocity;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isRunning;
    private bool canMove = true;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        cam = Camera.main.transform;
    }

    void Update()
    {
        // ����Ƿ��ڵ�����
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // ��Ծ
        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            Debug.Log("Player jumped with force: " + jumpForce);
        }

        // ����ܲ�״̬
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    void FixedUpdate()
    {
        if (!canMove) return;

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
            float speed = isRunning ? runSpeed : walkSpeed;

            // ����ƽ���ƶ�
            Vector3 targetVelocity = moveDir * speed;
            Vector3 velocityChange = targetVelocity - rb.velocity;
            velocityChange.y = 0; // ����Y���ϵ��ٶȲ���
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        else
        {
            // û������ʱ�𽥼���
            Vector3 velocity = rb.velocity;
            velocity.x = Mathf.Lerp(rb.velocity.x, 0, 0.1f);
            velocity.z = Mathf.Lerp(rb.velocity.z, 0, 0.1f);
            rb.velocity = velocity;
        }

        // Ӧ������
        if (!isGrounded)
        {
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
        if (!value) ResetVelocity(); // �����ֹ�ƶ��������ٶ�
        Debug.Log("Player can move: " + canMove);
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("MarioOdysseyCharacterController velocity reset.");
    }
}
