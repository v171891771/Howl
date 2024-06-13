using UnityEngine;
using System.Collections;

public class HookLockController : MonoBehaviour
{
    public float speed = 10f; // �������ٶ�
    private bool isMoving = false; // �����Ƿ����ƶ�
    private bool playerOnHookLock = false; // ����Ƿ��ڹ�����
    private GameObject player;
    private Vector3 playerOffset;
    private Vector3 initialPosition; // �����ĳ�ʼλ��
    private bool isRespawning = false; // �����Ƿ�������������

    void Start()
    {
        initialPosition = transform.position; // ��¼�����ĳ�ʼλ��
    }

    void Update()
    {
        if (isMoving)
        {
            MoveHookLock();
        }

        if (playerOnHookLock && player != null)
        {
            // ������Һ͹��������λ�ò���
            player.transform.position = transform.position + playerOffset;
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("HookLock started moving.");
    }

    public void StopMoving()
    {
        isMoving = false;
        Debug.Log("HookLock stopped moving.");
    }

    public void PlayerEnterHookLock(GameObject playerObject)
    {
        playerOnHookLock = true;
        player = playerObject;
        playerOffset = player.transform.position - transform.position;
        Debug.Log("Player entered HookLock.");
    }

    public void PlayerExitHookLock()
    {
        playerOnHookLock = false;
        if (player != null)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // ������ҵ��ٶ�Ϊ������ǰ������
                playerRigidbody.velocity = transform.forward * speed;
            }
            player = null;
        }
        StopMoving(); // �������ʱֹͣ����
        if (!isRespawning)
        {
            StartCoroutine(RespawnHookLock()); // ��������������Э��
        }
        Debug.Log("Player exited HookLock.");
    }

    private void MoveHookLock()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("HookLock is moving. Current position: " + transform.position);
    }

    private IEnumerator RespawnHookLock()
    {
        isRespawning = true; // ��ǹ�����������
        yield return new WaitForSeconds(3f); // �ȴ�����
        if (!playerOnHookLock) // ȷ����Ҳ��ڹ�����
        {
            transform.position = initialPosition; // ���������õ���ʼλ��
            Debug.Log("HookLock respawned at initial position.");
        }
        isRespawning = false; // ���ñ��
    }

    // Public property to access isMoving
    public bool IsMoving
    {
        get { return isMoving; }
    }
}
