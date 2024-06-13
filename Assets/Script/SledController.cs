using UnityEngine;
using System.Collections;

public class SledController : MonoBehaviour
{
    public float speed = 10f; // ��ѩ����ٶ�
    public float jumpForce = 5f; // ��Ծ��
    private bool isMoving = false; // ��ѩ���Ƿ����ƶ�
    private bool playerOnSled = false; // ����Ƿ��ڻ�ѩ����
    private GameObject player;
    private Vector3 playerOffset;
    private Vector3 initialPosition; // ��ѩ��ĳ�ʼλ��
    private Quaternion initialRotation; // ��ѩ��ĳ�ʼ��ת
    private bool isRespawning = false; // ��ѩ���Ƿ�������������
    private bool isJumping = false; // �Ƿ�����Ծ��

    void Start()
    {
        initialPosition = transform.position; // ��¼��ѩ��ĳ�ʼλ��
        initialRotation = transform.rotation; // ��¼��ѩ��ĳ�ʼ��ת
    }

    void Update()
    {
        if (isMoving)
        {
            MoveSled();
        }

        if (playerOnSled && player != null)
        {
            // ������Һͻ�ѩ������λ�ò���
            player.transform.position = transform.position + playerOffset;

            // ���ո�����½�����Ծ
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Jump();
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("Sled started moving.");
    }

    public void StopMoving()
    {
        isMoving = false;
        Debug.Log("Sled stopped moving.");
    }

    public void PlayerEnterSled(GameObject playerObject)
    {
        playerOnSled = true;
        player = playerObject;
        playerOffset = player.transform.position - transform.position;
        Debug.Log("Player entered sled.");
    }

    public void PlayerExitSled()
    {
        playerOnSled = false;
        if (player != null)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // ������ҵ��ٶ�Ϊ��ѩ���ǰ������
                playerRigidbody.velocity = transform.forward * speed;
            }
            player = null;
        }
        if (!isRespawning)
        {
            StartCoroutine(RespawnSled()); // ������ѩ��������Э��
        }
        Debug.Log("Player exited sled.");
    }

    private void MoveSled()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("Sled is moving. Current position: " + transform.position);
    }

    private IEnumerator RespawnSled()
    {
        isRespawning = true; // ��ǻ�ѩ����������
        yield return new WaitForSeconds(3f); // �ȴ�����
        if (!playerOnSled) // ȷ����Ҳ��ڻ�ѩ����
        {
            transform.position = initialPosition; // ����ѩ�����õ���ʼλ��
            transform.rotation = initialRotation; // ����ѩ�����õ���ʼ��ת
            StopMoving(); // ֹͣ��ѩ����ƶ�
            Debug.Log("Sled respawned at initial position and stopped moving.");
        }
        isRespawning = false; // ���ñ��
    }

    private void Jump()
    {
        if (player != null)
        {
            Rigidbody sledRigidbody = GetComponent<Rigidbody>();
            if (sledRigidbody != null)
            {
                sledRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
                StartCoroutine(ResetJump());
                Debug.Log("Sled jumped.");
            }
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f); // ������Ծ��ȴʱ��Ϊ1��
        isJumping = false;
        Debug.Log("Jump reset.");
    }

    // Public property to access isMoving
    public bool IsMoving
    {
        get { return isMoving; }
    }
}
